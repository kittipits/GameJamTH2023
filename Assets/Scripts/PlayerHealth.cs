using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    public bool isDead;
    private float timer;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private PlayerMovement movement;

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>(); 
    }

    private void Update()
    {

        if (isDead)
        {
            timer += Time.deltaTime;
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("game over"));
            //SceneManager.GetSceneByName("game over");
            
        }
        if (timer > 2f)
        {
            SceneManager.LoadScene("game over");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            //player hurt
            StartCoroutine(DamageFlash());
        }
        else
        {
            if (!isDead)
            {
                timer = 0;
                movement.canMove = false;
                spriteRend.enabled = false;
                isDead = true;
            }
        }
    }

    public void RestoreHP(float hp)
    {
        currentHealth = Mathf.Clamp(currentHealth + hp, 0, maxHealth);
    }

    private IEnumerator DamageFlash()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            Physics2D.IgnoreLayerCollision(10, 11, true);
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            Physics2D.IgnoreLayerCollision(10, 11, false);
        }
    }

}
