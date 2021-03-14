using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //module
    #region Module
    public CharacterAnimator characterAnimator;
    public CharacterControl characterControl;
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
