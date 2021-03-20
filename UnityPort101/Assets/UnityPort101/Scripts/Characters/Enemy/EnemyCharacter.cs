using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init()
    {
        characterAnimator.Init(this);
    }

    public override string GetCharacterId()
    {
        return "Enemy";
    }
}
