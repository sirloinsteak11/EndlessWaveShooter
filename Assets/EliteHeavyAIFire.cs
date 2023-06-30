using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteHeavyAIFire : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject eliteHeavyBullet;
    public int fireCooldown, fireCooldownAmount;
    public bool canFire;
    public Transform ehebs1, ehebs2, ehebs3, ehebs4, ehebs5, ehebs6, ehebs7, ehebs8;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireSfx;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = fireCooldownAmount;
        ehebs1 = transform.Find("EHEBS1").GetComponent<Transform>();
        ehebs2 = transform.Find("EHEBS2").GetComponent<Transform>();
        ehebs3 = transform.Find("EHEBS3").GetComponent<Transform>();
        ehebs4 = transform.Find("EHEBS4").GetComponent<Transform>();
        ehebs5 = transform.Find("EHEBS5").GetComponent<Transform>();
        ehebs6 = transform.Find("EHEBS6").GetComponent<Transform>();
        ehebs7 = transform.Find("EHEBS7").GetComponent<Transform>();
        ehebs8 = transform.Find("EHEBS8").GetComponent<Transform>();
        audioSource.clip = fireSfx;
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
            GameObject bulletClone1 = Instantiate(eliteHeavyBullet, ehebs1.position, ehebs1.rotation);
            bulletClone1.GetComponent<Rigidbody2D>().velocity = ehebs1.up * bulletSpeed;

            GameObject bulletClone2 = Instantiate(eliteHeavyBullet, ehebs2.position, ehebs2.rotation);
            bulletClone2.GetComponent<Rigidbody2D>().velocity = ehebs2.up * bulletSpeed;

            GameObject bulletClone3 = Instantiate(eliteHeavyBullet, ehebs3.position, ehebs3.rotation);
            bulletClone3.GetComponent<Rigidbody2D>().velocity = ehebs3.up * bulletSpeed;

            GameObject bulletClone4 = Instantiate(eliteHeavyBullet, ehebs4.position, ehebs4.rotation);
            bulletClone4.GetComponent<Rigidbody2D>().velocity = ehebs4.up * bulletSpeed;

            GameObject bulletClone5 = Instantiate(eliteHeavyBullet, ehebs5.position, ehebs5.rotation);
            bulletClone5.GetComponent<Rigidbody2D>().velocity = ehebs5.up * bulletSpeed;

            GameObject bulletClone6 = Instantiate(eliteHeavyBullet, ehebs6.position, ehebs6.rotation);
            bulletClone6.GetComponent<Rigidbody2D>().velocity = ehebs6.up * bulletSpeed;

            GameObject bulletClone7 = Instantiate(eliteHeavyBullet, ehebs7.position, ehebs7.rotation);
            bulletClone7.GetComponent<Rigidbody2D>().velocity = ehebs7.up * bulletSpeed;

            GameObject bulletClone8 = Instantiate(eliteHeavyBullet, ehebs8.position, ehebs8.rotation);
            bulletClone8.GetComponent<Rigidbody2D>().velocity = ehebs8.up * bulletSpeed;

            audioSource.Play();

            fireCooldown = fireCooldownAmount;
        }
    }
}
