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
            SaveAll();
        }

        // Press L to load
        if (Input.GetKeyDown(KeyCode.L))
        {
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
