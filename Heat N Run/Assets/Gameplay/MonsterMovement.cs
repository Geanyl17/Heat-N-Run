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

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        Debug.Log("Distance to player: " + distanceToPlayer);

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
                Debug.Log("Started chasing the player.");
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
        if (patrolDestination == 0)
        {
            MoveTowardsPatrolPoint(patrolPoints[0]);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1)
        {
            MoveTowardsPatrolPoint(patrolPoints[1]);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 0;
            }
        }
    }

    private void MoveTowardsPatrolPoint(Transform patrolPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, moveSpeed * Time.deltaTime);
    }
}
