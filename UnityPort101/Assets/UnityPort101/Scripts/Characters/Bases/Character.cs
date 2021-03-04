using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //module
    #region Module
    public CharacterAnimator characterAnimator;
    #endregion

    //method
    #region Method
    public abstract string GetAnimatorId();
    #endregion

    protected virtual void Awake()
    {
        characterAnimator = GetComponentInChildren<CharacterAnimator>();
    }
}
