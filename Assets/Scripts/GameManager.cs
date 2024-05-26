using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public ScoreManager scoreManager;
    public EnemySpawner enemySpawner;
    public WaveSystem waveSystem;
    public PlayerHP playerHP;
    public GameObject playerObject;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        scoreManager.ScoreView();

        gameOverUI.SetActive(true);
    }

    public void GameRestart()
    {
        enemySpawner.EndSpawnEnemies();
        enemySpawner.DeleteAllEnemies();
        playerObject.transform.position = Vector3.zero;
        gameOverUI.SetActive(false);

        Time.timeScale = 1f;

        scoreManager.ResetCurrentScore();
        waveSystem.ResetWave();
        waveSystem.StartNextWave();
        playerHP.ResetHP();
    }
}
