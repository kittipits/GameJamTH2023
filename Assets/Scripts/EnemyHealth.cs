using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

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
        Destroy(gameObject);
        //die animation
    }

}
