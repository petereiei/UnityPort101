using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActions_Player inputActions;

    private void Awake()
    {
        inputActions = new InputActions_Player();

        playerInput = GetComponent<PlayerInput>();
        playerInput.defaultActionMap = "Player";

        inputActions.Player.Movement.performed += Movement;
        inputActions.Player.Movement.canceled += Movement;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        
        var direction = context.ReadValue<Vector2>();

        Debug.Log($"direction: {direction}");

        // set movement game 3D, vector2 to vector3 
        Vector3 move = new Vector3
        {
            x = direction.x,
            z = direction.y
        }.normalized;

        transform.Translate(move * 5f * Time.deltaTime);
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
