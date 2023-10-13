using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
   