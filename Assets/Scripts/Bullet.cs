using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private int collisionDamage;
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
           direction  = player.transform.position - transform.position;
        }
        
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,0.5f));
        timer += Time.deltaTime;

        if (timer > 10) 
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(collisionDamage);
            Destroy(gameObject);
        }

    }
}
