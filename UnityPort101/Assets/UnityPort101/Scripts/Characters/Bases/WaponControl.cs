using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaponControl : MonoBehaviour
{
    private Character character;
    private WeaponSlot weaponSlot;

    public void Init(Character character)
    {
        this.character = character;

        weaponSlot = GetComponentInChildren<WeaponSlot>();
        weaponSlot.Init("Weapon_0001");

    }


}
