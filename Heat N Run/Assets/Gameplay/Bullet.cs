using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
{
    Debug.Log("Bullet hit something!");
    Enemy enemy = hitInfo.GetComponent<Enemy>();
    if (enemy != null)
    {
        Debug.Log("Bullet hit an enemy!");
        enemy.TakeDamage(damage);
        Destroy(gameObject);
        return;
    }

    BossEnemy Boss = hitInfo.GetComponent<BossEnemy>();
    if (Boss != null)
    {
        Debug.Log("Bullet hit the boss!");
        Boss.TakeDamage(damage);
        Destroy(gameObject);
    }
}

}
