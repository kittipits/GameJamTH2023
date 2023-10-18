using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool isDead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
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
                //anim.SetTrigger("die");
                gameObject.SetActive(false);
                isDead = true;
            }
        }
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
