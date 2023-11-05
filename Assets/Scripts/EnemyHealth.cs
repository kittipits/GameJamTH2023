using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth { get; private set; }
    public bool isDead = false;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    { 
        currentHealth -= damage;

        //play hurt animation

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        int randomNumber = Random.Range(1, 101);
        if (randomNumber <= 50)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        //die animation
    }

}
