using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private const string CHARACTER_ENEMY_OBJECT_PATH = "Prefabs/Characters/Bases/";

    public Transform pointSpawn;
    private List<EnemyCharacter> obects = new List<EnemyCharacter>();

    public void Start()
    {
        Spawn();
    }

    public  void Spawn() 
    {
        EnemyCharacter enemy = Instantiate(Resources.Load<EnemyCharacter>(CHARACTER_ENEMY_OBJECT_PATH + "Enemy/Enemy"), transform);
        enemy.transform.position = pointSpawn.position;
        enemy.transform.localScale = Vector3.one;

        enemy.Init();

        obects.Add(enemy);
    }
}
