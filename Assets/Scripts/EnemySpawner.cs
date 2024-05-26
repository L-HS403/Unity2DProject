using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 10;
    public float spawnDelay = 1.0f;
    public Vector2 mapSize = new Vector2(30, 30);

    public WaveSystem waveSystem;

    private int spawnedEnemies = 0;

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 randomPosition = GetRandomPosition();
            Instantiate(enemyPrefab, new Vector3(randomPosition.x, 0, randomPosition.y), Quaternion.identity);
            spawnedEnemies++;
            yield return new WaitForSeconds(spawnDelay);
        }

        while (spawnedEnemies > 0)
        {
            yield return null;
        }

        waveSystem.WaveCompleted();
    }

    Vector2 GetRandomPosition()
    {
        float x = Random.Range(-mapSize.x / 2, mapSize.x / 2);
        float y = Random.Range(-mapSize.y / 2, mapSize.y / 2);
        return new Vector2(x, y);
    }

    public void EnemyDestroyed()
    {
        spawnedEnemies--;
    }

    public void EndSpawnEnemies()
    {
        StopAllCoroutines();
        spawnedEnemies = 0;
    }

    public void DeleteAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
