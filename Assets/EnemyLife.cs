using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class enemyLife : MonoBehaviour
{

    public Rigidbody2D rb2d;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip hurtsfx;
    private Color originalColor;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        audiosource.clip = hurtsfx;
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        originalColor = GetComponent<SpriteRenderer>().color;
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
        audiosource.Play();
        StartCoroutine(ChangeColorOnHit());
    }

    private IEnumerator ChangeColorOnHit()
    {
        rend.color = Color.white;
        yield return new WaitForSeconds(.05f);
        rend.color = originalColor;


    }
}
