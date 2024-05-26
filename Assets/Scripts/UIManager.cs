using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject IdleUI;
    public GameObject methodUI;
    public GameObject sideUI;
    public GameObject pauseUI;
    public GameObject playerObject;
    public WaveSystem waveSystem;
    public GameManager gameManager;

    private void Start()
    {
        sideUI.SetActive(false);
    }

    public void OnClickStart()
    {
        playerObject.transform.position = Vector3.zero;
        mainUI.gameObject.SetActive(false);
        sideUI.gameObject.SetActive(true);
        pauseUI.gameObject.SetActive(false);
        waveSystem.StartNextWave();
    }

    public void OnClickMethod()
    {
        IdleUI.SetActive(false);
        methodUI.SetActive(true);
    }

    public void OnClickReturn()
    {
        methodUI.SetActive(false);
        IdleUI.SetActive(true);
    }

    public void OnClickPause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void OnClickResume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickRestart()
    {
        gameManager.GameRestart();
        pauseUI.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
