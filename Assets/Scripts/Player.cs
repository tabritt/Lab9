using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour , ISaveable
{
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;
    private ISaveable[] saveables;
    GameStateSave gameStateSave = new GameStateSave();


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();

    
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        saveables = FindObjectsOfType<MonoBehaviour>(true)
                   .OfType<ISaveable>()
                   .ToArray();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameStateSave.position = transform.position;
            gameStateSave.rotation = transform.rotation;
            gameStateSave.scale = transform.localScale;
            string json = JsonUtility.ToJson(gameStateSave, true);
            System.IO.File.WriteAllText(System.IO.Path.Combine(Application.persistentDataPath, "game_save.json"), json);
            SaveAll();
        }

        // Press L to load
        if (Input.GetKeyDown(KeyCode.L))
        {
            string json = System.IO.File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, "game_save.json"));
            GameStateSave loadedGameState = JsonUtility.FromJson<GameStateSave>(json);
            transform.position = loadedGameState.position;
            transform.rotation = loadedGameState.rotation;
            transform.localScale = loadedGameState.scale;
            LoadAll();
        }
    }
    public void SaveAll()
    {
        foreach (var s in saveables)
        {
            s.SaveData();
            Debug.Log("Saved: " + s.ToString());
        }
    }
    public void LoadAll()
    {
        foreach (var s in saveables)
        {
            s.LoadData();
        }
     
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
      
        Vector2 movement = new Vector2(moveInput.x, 0f);
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
    public void SaveData()
    {
        PlayerSaveTransform saveTransform = new PlayerSaveTransform(transform.position);
        string json = JsonUtility.ToJson(saveTransform, true); // pretty print = true

        // Save to a file
        File.WriteAllText(Application.persistentDataPath + "/playerSave.json", json);
        Debug.Log("Saved JSON: " + json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/playerSave.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerSaveTransform saveTransform = JsonUtility.FromJson<PlayerSaveTransform>(json);
            transform.position = saveTransform.ToVector2();
            Debug.Log("Loaded JSON: " + json);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }


}
