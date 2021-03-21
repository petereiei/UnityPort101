using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{
   
    public void TakeDamage(Character attacker)
    {
        Debug.Log($"TakeDamage: {attacker.transform.name}");
    }
}
