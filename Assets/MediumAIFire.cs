using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumAIFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject mediumBullet;
    public int fireCooldown, fireCooldownAmount;
    public bool canFire;
    public Transform mebs1, mebs2, mebs3;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = fireCooldownAmount;
        mebs1 = transform.Find("MEBS1").GetComponent<Transform>();
        mebs2 = transform.Find("MEBS2").GetComponent<Transform>();
        mebs3 = transform.Find("MEBS3").GetComponent<Transform>();
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
            GameObject bulletClone1 = Instantiate(mediumBullet, mebs1.position, transform.rotation);
            bulletClone1.GetComponent<Rigidbody2D>().velocity = mebs1.up * bulletSpeed;

            GameObject bulletClone2 = Instantiate(mediumBullet, mebs2.position, mebs2.rotation);
            bulletClone2.GetComponent<Rigidbody2D>().velocity = mebs2.up * bulletSpeed;

            GameObject bulletClone3 = Instantiate(mediumBullet, mebs3.position, mebs3.rotation);
            bulletClone3.GetComponent<Rigidbody2D>().velocity = mebs3.up * bulletSpeed;

            fireCooldown = fireCooldownAmount;
        }
    }
}
