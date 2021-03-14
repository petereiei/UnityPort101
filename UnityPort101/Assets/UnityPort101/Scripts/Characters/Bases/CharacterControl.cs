using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character character;
    protected Vector3 rawDirection;

    [Header("Movement Settings")]
    public float movementSpeed = 1f;
    public float turnSpeed = 0.1f;
    public float movementSmoothingSpeed = 1f;
    private Vector3 smoothInputMovement;
    protected Vector3 rawInputMovement;


    public virtual void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public virtual void Init(Character character)
    {
        this.character = character;
    }

    private void Update()
    {
        CalculateMovementInputSmoothing();
        UpdateDirection();
    }

    void FixedUpdate()
    {
        Movement();
        TurnThePlayer();
    }

    private void Movement()
    {
        rigidBody.MovePosition(rigidBody.position + rawDirection * movementSpeed * Time.deltaTime);

        character.onMove?.Invoke(rawDirection);
    }

    void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    public void UpdateDirection()
    {
        rawDirection = smoothInputMovement;
    }

    private void TurnThePlayer()
    {
        if (rawDirection.sqrMagnitude > 0.01f)
        {
            Quaternion rotation = Quaternion.Slerp(rigidBody.rotation, Quaternion.LookRotation(rawDirection), turnSpeed);

            rigidBody.MoveRotation(rotation);
        }
    }

    public void OnAttack()
    {
        Debug.Log("Player Attack");

        character.onAttack?.Invoke(character);
    }

}
