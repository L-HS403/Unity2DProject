using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct Wave
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float spawnDelay;
}

public class WaveSystem : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameManager gameManager;
    public TextMeshProUGUI WaveText;

    public float timeBetweenWaves = 30.0f;
    public Wave[] waves;

    private int currentWave = 0;

    private void Update()
    {
        WaveText.text = "Wave: " + currentWave.ToString() + " / " + waves.Length.ToString();
    }

    public void WaveCompleted()
    {
        if (currentWave < waves.Length)
        {
            StartCoroutine(WaitForNextWave());
        }
        else
        {
            Debug.Log("All waves completed!");
            gameManager.GameOver();
        }
    }

    IEnumerator WaitForNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartNextWave();
    }

    public void StartNextWave()
    {
        if (currentWave < waves.Length)
        {
            Wave wave = waves[currentWave];
            enemySpawner.enemyPrefab = wave.enemyPrefab;
            enemySpawner.enemyCount = wave.enemyCount;
            enemySpawner.spawnDelay = wave.spawnDelay;
            currentWave++;
            enemySpawner.StartCoroutine(enemySpawner.SpawnEnemies());
        }

        else
        {
            gameManager.GameOver();
        }
    }

    public void ResetWave()
    {
        currentWave = 0;
    }
}
