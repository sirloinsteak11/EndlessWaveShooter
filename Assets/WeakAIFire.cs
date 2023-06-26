using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAIFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject weakBullet;
    public int fireCooldown, fireCooldownAmount;
    public bool canFire;
    public Transform bulletSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = fireCooldownAmount;
        bulletSpawnLocation = transform.Find("weakEnemyBulletSpawn").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireCooldown > 0)
        {
            fireCooldown--;
        }

        if (fireCooldown < 1)
        {
            GameObject bulletClone = Instantiate(weakBullet, bulletSpawnLocation.position, transform.rotation);

            bulletClone.GetComponent<Rigidbody2D>().velocity = bulletSpawnLocation.up * bulletSpeed;

            fireCooldown = fireCooldownAmount;
        }
    }
}
