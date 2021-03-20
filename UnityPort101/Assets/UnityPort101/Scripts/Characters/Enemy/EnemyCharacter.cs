using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public EnemyAttribute enemyAttribute;
    protected override void Awake()
    {
        base.Awake();
        enemyAttribute = gameObject.AddComponent<EnemyAttribute>();
        attribute = enemyAttribute;
    }

    public void Init()
    {
        enemyAttribute.Init();
        characterAnimator.Init(this);
    }

    public override string GetCharacterId()
    {
        return "Enemy";
    }
}
