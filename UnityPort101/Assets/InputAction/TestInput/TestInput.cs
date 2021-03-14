using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActions_Player inputActions;

    public float movementSmoothingSpeed = 5f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    private Vector3 movementDirection;
    private Camera mainCamera;

    [Header("Component References")]
    public Rigidbody playerRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 0.1f;
    public float turnSpeed = 0.1f;

    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); ;
        playerRigidbody = GetComponent<Rigidbody>();
        inputActions = new InputActions_Player();

        playerInput = GetComponent<PlayerInput>();
        playerInput.defaultActionMap = "Player";

        inputActions.Player.Movement.performed += Movement;
        inputActions.Player.Movement.canceled += Movement;
    }

    void Update()
    {
        CalculateMovementInputSmoothing();
        movementDirection = smoothInputMovement;
    }

    private void FixedUpdate()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        
        var direction = context.ReadValue<Vector2>();
        Debug.Log($"direction: {direction}");

        rawInputMovement = new Vector3(direction.x, 0, direction.y);

        //Debug.Log($"direction: {direction}");

        //// set movement game 3D, vector2 to vector3 
        //Vector3 move = new Vector3
        //{
        //    x = direction.x,
        //    z = direction.y
        //}.normalized;

        //transform.Translate(move * 5f * Time.deltaTime);
    }

    void CalculateMovementInputSmoothing()
    {

        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    }

    void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

    }

    void TurnThePlayer()
    {
        if (movementDirection.sqrMagnitude > 0.01f)
        {

            Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation,
                                                 Quaternion.LookRotation(CameraDirection(movementDirection)),
                                                 turnSpeed);

            playerRigidbody.MoveRotation(rotation);

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
}
