using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnJumpKeyDown();
public delegate void OnJumpKeyUp();

public delegate void OnRunKeyDown();
public delegate void OnRunKeyUp();

public delegate void OnRmouseDown();
public delegate void OnRmouseUp();
public delegate void OnLmouseDown();
public delegate void OnLmouseUp();


public class InputManager : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;
    [SerializeField] private KeyCode rMouseButton, lMouseButton;
    public KeyCode jumpKey, crouchKey, runKey;

    public float hInput { get; private set; }
    public float vInput { get; private set; }

    public bool jumpKeyPressed { get; private set; } = false;
    public bool runKeyPressed { get; private set; } = false;
    public bool leftMouseButtonPressed { get; private set; } = false;
    public bool rightMouseButtonPressed { get; private set; } = false;

    //Singleton
    private static InputManager instance;
    public static InputManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        hInput = Input.GetAxisRaw(horizontalAxis);
        vInput = Input.GetAxisRaw(verticalAxis);

        jumpKeyPressed = Input.GetKey(jumpKey);
        runKeyPressed = Input.GetKey(runKey);
        rightMouseButtonPressed = Input.GetKey(rMouseButton);
        leftMouseButtonPressed = Input.GetKey(lMouseButton);
    }
}
