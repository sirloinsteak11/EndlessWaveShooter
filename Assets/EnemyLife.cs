using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class enemyLife : MonoBehaviour
{

    public GameObject enemy;
    public Rigidbody2D rb2d;
    private Renderer rend;
    private Color originalColor;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<GameObject>();
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        originalColor = GetComponent<Renderer>().material.color;
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
        ChangeColorOnHit();
    }

    private IEnumerator ChangeColorOnHit()
    {
        rend.material.color = Color.white;
        yield return new WaitForSeconds(.5f);
        rend.material.color = originalColor;
    }
}
