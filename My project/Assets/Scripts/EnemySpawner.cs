using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;

    private int currentEnemies = 0;

    public void OnEnemyDeath()
    {
        currentEnemies--;
    }

    private void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float minX = transform.position.x - transform.localScale.x / 2f;
        float maxX = transform.position.x + transform.localScale.x / 2f;
        float minZ = transform.position.z - transform.localScale.z / 2f;
        float maxZ = transform.position.z + transform.localScale.z / 2f;
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition  = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
}
