using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public PlayerHealth playerHealth;
    public Transform[] spawnPoints;

    public float spawnTime = 3f;

    private void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnTime);
    }

    private void Spawn()
    {
        if (playerHealth.currHealth <= 0)
            return;

        int index = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[index].position,spawnPoints[index].rotation );

    }


}
