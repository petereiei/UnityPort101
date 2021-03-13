using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.Player.Movement.performed += ctx => Movement(ctx.ReadValue<Vector2>());
    }

    private void Movement(Vector2 direction)
    {
        // set movement game 3D, vector2 to vector3 
        Vector3 move = new Vector3
        {
            x = direction.x,
            z = direction.y
        }.normalized;

        transform.Translate(move * 5f * Time.deltaTime);
    }
}
