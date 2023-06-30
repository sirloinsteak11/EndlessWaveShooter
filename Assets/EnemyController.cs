using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject weakEnemy, mediumEnemy, eliteEnemy, eliteHeavyEnemy;
    public GameController GameController;

    // message in the editor that informs user thaT spawnInterval value is in seconds and not ms
    public bool spawnIntervalIsInSeconds;
    public float spawnInterval;

    public IEnumerator CreateEnemy(string enemyClass, Transform[] spawn, int times = 1)
    {
        // Instantiate(enemySprite, position, Quaternion.identity);

        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (enemyClass == "weak")
            {
                Instantiate(weakEnemy, spawn[UnityEngine.Random.Range(0, spawn.Length)].position, Quaternion.identity);
            }
            if (enemyClass == "medium")
            {
                Instantiate(mediumEnemy, spawn[UnityEngine.Random.Range(0, spawn.Length)].position, Quaternion.identity);
            }
            if (enemyClass == "elite")
            {
                Instantiate(eliteEnemy, spawn[UnityEngine.Random.Range(0, spawn.Length)].position, Quaternion.identity);
            }
            if (enemyClass == "eliteHeavy")
            {
                Instantiate(eliteHeavyEnemy, spawn[UnityEngine.Random.Range(0, spawn.Length)].position, Quaternion.identity);
            }

            GameController.enemiesSpawned++;
        }
    }
}
