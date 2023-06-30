using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed, bulletSpeed;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject playerBullet, playerDeathParticle, invincCircle;
    private SpriteRenderer rend;
    public GameController GameController;
    public int iframe, iframeValue, fireCooldown, fireCooldownAmount;
    public bool isInvisible, canFire;
    public Transform bulletSpawnLocation;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip hurtsfx;
    public PlayerDeathNoiseController pdnc;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = hurtsfx;
        rend = GetComponent<SpriteRenderer>();
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
            StartCoroutine(InvincibilityColorFlash());
        } else
        {
            isInvisible = false;
            invincCircle.SetActive(false);
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

    async public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!isInvisible)
            {
                playerDeathParticle.transform.position = transform.position;
                playerDeathParticle.GetComponent<ParticleSystem>().Play();
                GameController.lifeCount--;
                await Respawn();
                //iframe = iframeValue;
            }
        }
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            if (!isInvisible)
            {
                playerDeathParticle.transform.position = transform.position;
                playerDeathParticle.GetComponent<ParticleSystem>().Play();
                GameController.lifeCount--;
                await Respawn();
            }
        }
    }

    public void FireBullet()
    {
        Debug.Log("fire!");
        GameObject bulletClone = Instantiate(playerBullet, bulletSpawnLocation.position, transform.rotation);

        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnLocation.up * bulletSpeed;
    }

    async public Task Respawn()
    {
        pdnc.PlayDeathNoise();
        gameObject.SetActive(false);

        await Task.Delay(2000);

        if (GameController.lifeCount > 0)
        {
            gameObject.SetActive(true);
            transform.position = new Vector3(0, 0, 0);
            invincCircle.SetActive(true);
            iframe = iframeValue;
        }
    }

    public IEnumerator InvincibilityColorFlash()
    {
        yield return new WaitForSeconds(0.01f);
        rend.color = Color.clear;
        yield return new WaitForSeconds(0.01f);
        rend.color = Color.white;
    }
}
