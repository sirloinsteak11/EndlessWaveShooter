using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{

    public GameObject player;
    public float speed;
    private float distance;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 90));

        if (distance > 2.5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (distance < 2.5)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position - new Vector3(2, 2, 0), -speed * Time.deltaTime);
        } 
    }
}
