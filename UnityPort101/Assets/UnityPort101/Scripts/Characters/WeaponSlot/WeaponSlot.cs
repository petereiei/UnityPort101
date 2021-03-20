using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private const string WEAPON_OBJECT_PATH = "Prefabs/Weapons/";

    private string weaponId;
    private GameObject characterWeapon;

    public void Init(string weaponId)
    {
        this.weaponId = weaponId;

        if (characterWeapon != null)
            Destroy(characterWeapon);

        GenerateWeapon();
    }

    private void GenerateWeapon()
    {
        GameObject weapon = Instantiate(Resources.Load<GameObject>(WEAPON_OBJECT_PATH + weaponId), transform);
        weapon.transform.localScale = Vector3.one;

        characterWeapon = weapon;
    }
}
