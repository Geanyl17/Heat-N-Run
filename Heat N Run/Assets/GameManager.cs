using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject victoryPanel;

    private void Update()
    {
        if (gameOverUI != null && victoryPanel != null)
        {
            if (gameOverUI.activeInHierarchy || victoryPanel.activeInHierarchy)
            {
                // Removed cursor lock and visibility settings
            }
            else
            {
                // Removed cursor lock and visibility settings
            }
        }
    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void Victory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
