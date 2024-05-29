using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask obstacleLayers;

    public Animator animator;

    void Update()
    {
        if (Time.time >= nextAttackTime && Input.GetMouseButtonDown(0))
        {
            Use();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public override void Use()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        
        Collider2D[] hitObstacles = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, obstacleLayers);
        foreach (Collider2D obstacle in hitObstacles)
        {
            obstacle.GetComponent<ObstacleHealth>().TakeDamage(30);
        }
    
    
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
