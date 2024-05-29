using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public float stopChaseDistance; // Add a separate distance to stop chasing

    void Update()
    {
        if (playerTransform == null)
        {
            Debug.LogError("PlayerTransform is not set!");
            return;
        }

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("Patrol points are not set!");
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (isChasing)
        {
            if (distanceToPlayer > stopChaseDistance)
            {
                isChasing = false;
                return;
            }

            ChasePlayer();
        }
        else
        {
            if (distanceToPlayer < chaseDistance)
            {
                isChasing = true;
            }
            else
            {
                Patrol();
            }
        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("No patrol points set for monster!");
            return;
        }

        // Ensure patrolDestination is within bounds
        if (patrolDestination < 0 || patrolDestination >= patrolPoints.Length)
        {
            Debug.LogError("Patrol destination index out of bounds!");
            patrolDestination = 0; // Reset to a valid index
        }

        Transform targetPatrolPoint = patrolPoints[patrolDestination];
        MoveTowardsPatrolPoint(targetPatrolPoint);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < 0.2f)
        {
            // Reverse direction by switching to the next patrol point
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1); // Flip the monster
        }
    }

    private void MoveTowardsPatrolPoint(Transform patrolPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, moveSpeed * Time.deltaTime);
    }
}
