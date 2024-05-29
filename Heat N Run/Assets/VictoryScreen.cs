using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void ShowVictoryScreen()
    {
        victoryPanel.SetActive(true);
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
