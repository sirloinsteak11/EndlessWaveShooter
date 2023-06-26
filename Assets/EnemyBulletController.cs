using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private void FixedUpdate()
    {
        int bulletTimer = 100;
        bulletTimer--;

        if (bulletTimer == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            return;
        }

        if (collision.collider.CompareTag("EnemyBullet"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
