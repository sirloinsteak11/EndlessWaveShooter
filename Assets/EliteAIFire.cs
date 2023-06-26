using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EliteAIFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject EliteBullet;
    public int fireCooldown, fireCooldownAmount, bulletFireInterval; //bulletFireInterval in ms
    public bool canFire;
    public Transform bulletSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }

    async Task TripleShot(int times)
    {
        for (int i = 0; i < times; i++)
        {
            GameObject bulletClone = Instantiate(EliteBullet, bulletSpawnLocation.position, transform.rotation);

            bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnLocation.up * bulletSpeed;

            await Task.Delay(bulletFireInterval);
        }
        fireCooldown = fireCooldownAmount;
    }
}
