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
    public int spawnInterval;

    async public Task CreateEnemy(string enemyClass, Vector3 position, int times = 1)
    {
        // Instantiate(enemySprite, position, Quaternion.identity);

        for (int i = 0; i < times; i++)
        {
            await Task.Delay((int)(spawnInterval * 1000));

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

            GameController.enemiesSpawned++;
        }
    }
}
