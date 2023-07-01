using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EliteAIFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject EliteBullet;
    public int fireCooldown, fireCooldownAmount, bulletFireInterval, bulletCount; //bulletFireInterval in ms
    public bool canFire;
    public Transform bulletSpawnLocation;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireSfx;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = fireSfx;
        fireCooldown = fireCooldownAmount;
        bulletSpawnLocation = transform.Find("eliteEnemyBulletSpawn").GetComponent<Transform>();
    }

    // Update is called once per frame
    async void FixedUpdate()
    {
        if (fireCooldown > 0)
        {
            fireCooldown--;
        }

        if (fireCooldown < 1)
        {
            await TripleShot(3);
            fireCooldown = fireCooldownAmount;
        }
    }

    async Task TripleShot(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (bulletCount < 3)
            {
                GameObject bulletClone = Instantiate(EliteBullet, bulletSpawnLocation.position, transform.rotation);

                bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnLocation.up * bulletSpeed;

                await Task.Delay(bulletFireInterval);
            }
        }
        bulletCount = 0;
        audioSource.Play();
    }
}
