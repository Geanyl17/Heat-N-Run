using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject bossRoomPromptUI; // Reference to the UI panel

    private bool playerInRange;

    void Update()
    {
        // Check if player is in range and presses the interaction key
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the prompt UI
            bossRoomPromptUI.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            bossRoomPromptUI.SetActive(false); // Hide the prompt UI when the player leaves
        }
    }

    // Call this method to enter the boss room
    public void EnterBossRoom()
    {
        // Code to load the boss room scene
        Debug.Log("Entering the Boss Room!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Call this method to cancel entering the boss room
    public void CancelBossRoom()
    {
        bossRoomPromptUI.SetActive(false);
    }
}
