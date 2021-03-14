using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : CharacterControl
{
    protected InputActions_Player inputActions;
    //private Vector3 rawInputMovement;

    public override void Awake()
    {
        base.Awake();

        inputActions = new InputActions_Player();
    }

    public override void Init(Character character)
    {
        base.Init(character);

        inputActions.Player.Movement.performed += InputMovement;
        inputActions.Player.Movement.canceled += InputMovement;

        inputActions.Player.Attack.performed += OnAttack;
    }

    private void InputMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        rawInputMovement = new Vector3(direction.x, 0, direction.y);
    }

    private void OnAttack(InputAction.CallbackContext value)
    {
        OnAttack();
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
