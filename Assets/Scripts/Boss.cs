using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    EnemyHealth bossHealth;
    public GameObject finish;
    public Transform finishPos;

    private bool levelcompleted = false;

    private void Start()
    {
        bossHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (bossHealth.currentHealth <= 0)
        {
            Instantiate(finish, finishPos.position, Quaternion.identity); 
            levelcompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
