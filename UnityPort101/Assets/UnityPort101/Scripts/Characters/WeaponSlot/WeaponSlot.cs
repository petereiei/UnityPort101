using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private const string WEAPON_OBJECT_PATH = "Prefabs/Weapons/";

    private string weaponId;
    private Weapon characterWeapon;

    public void Init(string weaponId)
    {
        this.weaponId = weaponId;

        if (characterWeapon != null)
            Destroy(characterWeapon);

        GenerateWeapon();
    }

    private void GenerateWeapon()
    {
        Weapon weapon = Instantiate(Resources.Load<Weapon>(WEAPON_OBJECT_PATH + weaponId), transform);
        weapon.transform.localScale = Vector3.one;

        weapon.Init();

        characterWeapon = weapon;
    }
}
