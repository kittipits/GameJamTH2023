using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.Knockback(transform);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.Knockback(transform);
        }
    }

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    var player = other.collider.GetComponent<PlayerMovement>();
    //    if (player != null)
    //    {
    //        player.Knockback(transform);
    //    }
    //}
}
