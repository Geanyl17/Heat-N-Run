using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;
    public LayerMask whatIsPlayer;

    public GameObject confirmationUI;

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ShowConfirmation();
            }
        }
    }

    private void ShowConfirmation()
    {
        // Show the confirmation UI
        confirmationUI.SetActive(true);
    }

    public void ConfirmEnterBossRoom()
    {
        // Hide the confirmation UI
        confirmationUI.SetActive(false);
        
        // Load the BossRoom scene
        SceneController.instance.LoadScene("BossRoom");
    }

    public void CancelEnterBossRoom()
    {
        // Hide the confirmation UI
        confirmationUI.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
