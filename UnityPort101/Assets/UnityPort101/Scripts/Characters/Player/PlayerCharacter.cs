using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public PlayerAttribute playerAttribute;
    protected override void Awake()
    {
        base.Awake();
        playerAttribute = gameObject.AddComponent<PlayerAttribute>();
        attribute = playerAttribute;
        characterControl = gameObject.GetComponent<PlayerControl>();
        waponControl = gameObject.GetComponentInChildren<WaponControl>();
    }

    public void Init()
    {
        playerAttribute.Init();
        characterAnimator.Init(this);
        characterControl.Init(this);
        waponControl.Init(this);

        onMove += characterAnimator.OnRun;
        onAttack += characterAnimator.OnAttack;
    }

    public override string GetCharacterId()
    {
        return "Player";
    }

}
