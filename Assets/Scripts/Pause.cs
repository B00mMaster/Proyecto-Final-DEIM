using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pausee();
        }
    }

    void Pausee()
    {
        if(pausePanel != null)
        {
            bool isPaused=!pausePanel.activeSelf;
            PauseState(isPaused);
        }
    }

    void PauseState(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
