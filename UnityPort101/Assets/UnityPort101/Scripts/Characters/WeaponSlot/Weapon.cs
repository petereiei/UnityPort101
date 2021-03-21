using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private BoxCollider boxCollider;

    public void Init()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void SetActiveTrigger()
    {
        boxCollider.isTrigger = true;
    }

    public void ResetActiveTrigger()
    {
        boxCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponentsInParent<Character>();

        foreach (var attack in character)
            attack.attribute.TakeDamage(attack);
    }
}
