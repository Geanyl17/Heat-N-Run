using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBulletScript : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D rb;
    private float timer;
    public float force;
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;

            if(timer > 10)
            {
                Destroy(gameObject);
            }
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             Health healthComponent = other.gameObject.GetComponent<Health>();
             if (healthComponent != null)
            {
            healthComponent.TakeDamage(10);
            Destroy(gameObject);
            }
        }
    }



}
