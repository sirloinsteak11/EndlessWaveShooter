using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject weakEnemy, mediumEnemy, eliteEnemy, eliteHeavyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEnemy(string enemyClass, Vector3 position)
    {
        // Instantiate(enemySprite, position, Quaternion.identity);

        if (enemyClass == "weak")
        {
            Instantiate(weakEnemy, position, Quaternion.identity);
        }
        if (enemyClass == "medium")
        {
            Instantiate(mediumEnemy, position, Quaternion.identity);
        }
        if (enemyClass == "elite")
        {
            Instantiate(eliteEnemy, position, Quaternion.identity);
        }
        if (enemyClass == "eliteHeavy")
        {
            Instantiate(eliteHeavyEnemy, position, Quaternion.identity);
        }
    }
}
