using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : Singleton<MenuPause>
{
    public GameObject pauseMenuUI;
    public GameObject imaage;

    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f; // Arrête le temps
        pauseMenuUI.SetActive(true);
        imaage.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Reprend le temps
        pauseMenuUI.SetActive(false);
        imaage.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
