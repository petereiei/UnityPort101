using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character character;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public virtual void Init(Character character)
    {
        this.character = character;
    }

    public void Move(Vector3 direction)
    {
        rigidBody.MovePosition(rigidBody.position + direction * 5f);
    }
}
