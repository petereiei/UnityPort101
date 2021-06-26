using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character character;
    protected Vector3 rawDirection;

    [Header("Movement Settings")]
    private float movementSpeed = 3f;
    private float turnSpeed = 0.1f;
    private float movementSmoothingSpeed = 5f;
    private Vector3 smoothInputMovement;
    protected Vector3 rawInputMovement;

    public Camera mainCamera;


    public virtual void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public virtual void Init(Character character)
    {
        this.character = character;

        mainCamera = FindObjectOfType<Camera>();
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

        Vector3 movement = CameraDirection(rawDirection) * movementSpeed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);

        character.onMove?.Invoke(rawInputMovement);
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

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

            Quaternion rotation = Quaternion.Slerp(rigidBody.rotation,
                                                 Quaternion.LookRotation(CameraDirection(rawDirection)),
                                                 turnSpeed);

            rigidBody.MoveRotation(rotation);
        }

    }

    public void OnAttack()
    {
        Debug.Log("Player Attack");

        character.onAttack?.Invoke(character);
    }

}
