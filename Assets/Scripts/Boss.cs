using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    EnemyHealth bossHealth;

    private bool levelcompleted = false;

    private void Start()
    {
        bossHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (bossHealth.isDead)
        {
            levelcompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
