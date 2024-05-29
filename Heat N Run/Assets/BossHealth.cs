using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 1000;
    int currentHealth;
    public BossHealthBar BossBar;
    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        BossBar.SetMaxHealth(maxHealth);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

        BossBar.SetHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Wait until the "isDead" animation has finished playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Display the victory screen
        gameManager.Victory();

        // Destroy the game object
        Destroy(gameObject);
    }
}
