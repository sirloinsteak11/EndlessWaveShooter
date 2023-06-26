using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed, bulletSpeed;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject playerBullet;
    public GameController GameController;
    public int iframe, iframeValue, fireCooldown, fireCooldownAmount;
    public bool isInvisible, canFire;
    public Transform bulletSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isInvisible = false;
        fireCooldown = 0;
        canFire = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canFire)
            {
                FireBullet();
                fireCooldown += fireCooldownAmount;
            }
        }
       /* if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
        } */
    }

    // Update is called once per frame, fixed
    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        Vector2 rbMove = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        rb2d.AddForce(rbMove);

        transform.up = direction;

        if (iframe > 0)
        {
            isInvisible = true;
            iframe--;
        } else
        {
            isInvisible = false;
        }

        if (fireCooldown > 0)
        {
            fireCooldown--;
            canFire = false;
        } else
        {
            canFire = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!isInvisible)
            {
                GameController.lifeCount--;
                iframe = iframeValue;
            }
        }
    }

    public void FireBullet()
    {
        Debug.Log("fire!");
        GameObject bulletClone = Instantiate(playerBullet, bulletSpawnLocation.position, transform.rotation);

        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnLocation.up * bulletSpeed;
    }
}
