using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{

    protected override void Awake()
    {
        base.Awake();

        characterControl = gameObject.GetComponent<PlayerControl>();
    }

    public void Init()
    {
        characterAnimator.Init(this);
        characterControl.Init(this);

        onMove += characterAnimator.OnRun;
        onAttack += characterAnimator.OnAttack;
    }

    public override string GetCharacterId()
    {
        return "Player";
    }

}
