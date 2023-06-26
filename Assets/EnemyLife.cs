using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{

    public GameObject enemy;
    public Rigidbody2D rb2d;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<GameObject>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Bullet"))
        {
            return;
        }
        life--;
    }
}
