using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string CHARACTER_OBJECT_PATH = "Prefabs/Characters/Models/";

    protected Animator animator;
    protected Character character;
    protected GameObject characterObject;

    public void Init(Character character)
    {
        this.character = character;
        SetAnimator();
    }

    private void SetAnimator()
    {
        characterObject = Instantiate(Resources.Load<GameObject>(CHARACTER_OBJECT_PATH + character.GetCharacterId()), transform);
        this.animator = characterObject.GetComponentInChildren<Animator>();
    }
}
