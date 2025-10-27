using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
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



}
