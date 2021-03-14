using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : CharacterControl
{
    protected InputActions_Player inputActions;
    private Vector3 rawInputMovement;

    protected void Awake()
    {
        inputActions = new InputActions_Player();

        inputActions.Player.Movement.performed += InputMovement;
        inputActions.Player.Movement.canceled += InputMovement;

        Debug.Log("PlayerControl Awake");
    }

    public override void Init(Character character)
    {
        Debug.Log("PlayerControl Init");
        base.Init(character);
    }

    private void InputMovement(InputAction.CallbackContext context)
    {
        Debug.Log("InputMovement");
        Vector2 direction = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(direction.x, 0, direction.y);

        Move(rawInputMovement);
    }
}
