using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private float collisionDamage;
    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        timer = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(collisionDamage);
        }
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && timer % 60 >= 55)
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(collisionDamage);
        }
    }

    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        timer = 0;
    }
}
