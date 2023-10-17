using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackTime = 0.5f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    private Rigidbody2D rb;

    private Coroutine knockbackCoroutine;

    public bool IsBeingKnockback { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection)
    {
        IsBeingKnockback = true;

        Vector2 hitForce;
        Vector2 constantForce;
        Vector2 knockbackForce;
        Vector2 combinedForce;

        hitForce = hitDirection * hitDirectionForce;
        constantForce = constantForceDirection * constForce;

        float elapesdTime = 0f;
        while (elapesdTime < knockbackTime)
        { 
            elapesdTime += Time.fixedDeltaTime;

            knockbackForce = hitForce * constantForce;

            if (inputDirection != 0)
            {
                combinedForce = knockbackForce + new Vector2(inputDirection * inputForce, 0f);
            }
            else 
            {
                combinedForce = knockbackForce;
            }

            rb.velocity = combinedForce;

            yield return new WaitForFixedUpdate();
        }

        IsBeingKnockback = false;
    }

    public void CallKnockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputDirection) 
    {
        knockbackCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputDirection));
    }
}
