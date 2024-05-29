using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health; 
    public int maxHealth = 100;
    public Animator animator;

    public HealthBar healthBar;
    public GameManager gameManager;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
public void TakeDamage(int amount)
{
    animator.SetTrigger("Hurt");
    
    health -= amount;
    
    if( health <= 0 && !isDead)
    {
        isDead = true;
        gameManager.GameOver();
        Destroy(gameObject);
    }

    healthBar.SetHealth(health);

}

    void Update()
    {
        
    }
}
