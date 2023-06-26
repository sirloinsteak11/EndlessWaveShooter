using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            return;
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            return;
        }
        Destroy(gameObject);
    } 
}
