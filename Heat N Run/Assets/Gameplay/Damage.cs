using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Health playerHealth;
    public int damage = 2;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
             playerMovement.controller.KBCounter = playerMovement.controller.KBTotalTime;

            // Determine the direction of knockback
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.controller.KnockFromRight = true;
            }
            else
            {
                playerMovement.controller.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}