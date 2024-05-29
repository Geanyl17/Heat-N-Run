using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public Animator animator;
    private float m_FireTime = 2f;
    public Vector2 m_Offset;
    
    private float timer = 0;
    private float nextInterval;
    public float minTime = 0.0f; // Minimum interval time
    public float maxTime = 5.0f; // Maximum interval time
    // Start is called before the first frame update
  void Start()
    {
        // Set the initial random interval
        SetNextInterval();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextInterval)
        {
            timer = 0;
            shoot();
            // Set the next random interval
            SetNextInterval();
        }
    }

    void shoot()
    {
        animator.SetTrigger("Attack");
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Shoot!");
    }

    void SetNextInterval()
    {
        nextInterval = Random.Range(minTime, maxTime);
        Debug.Log("Next interval: " + nextInterval);
    }






}
