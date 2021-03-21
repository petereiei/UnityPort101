using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public CharacterAttribute attribute;

    //module
    #region Module
    public CharacterAnimator characterAnimator;
    public CharacterControl characterControl;
    public WaponControl waponControl;
    #endregion

    //event
    #region Method
    public Action<Vector3> onMove;
    public Action<Character> onAttack;
    #endregion

    //method
    #region Method
    public abstract string GetCharacterId();
    #endregion

    protected virtual void Awake()
    {
        characterAnimator = GetComponentInChildren<CharacterAnimator>();
    }
}
