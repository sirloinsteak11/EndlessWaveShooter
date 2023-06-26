using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] Button startButton, changeRoundButtton;

    public EnemyController EnemyController;

    public int waveCount, lifeCount, enemyCount, enemiesPresent, enemiesSpawned;
    [SerializeField] float score, scoreFactor, enemyIncreaseFactor;
    [SerializeField] internal bool hasStarted, enemiesFinishedSpawning, canSpawn;
    internal string[] enemyClasses = { "weak", "medium", "elite", "eliteHeavy" };

    // in ms, time between each enemy spawn
    public int spawnInterval, initialSpawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        waveCount = 0;
        lifeCount = 3;
        enemiesPresent = 0;
        hasStarted = false;
        startButton.onClick.AddListener(StartGame);
        changeRoundButtton.onClick.AddListener(RoundChange);
        spawnInterval = initialSpawnInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = Math.Floor(score).ToString();
        waveText.text = $"Wave: {waveCount}";
        lifeText.text = $"Lives: {lifeCount}";

        enemiesPresent = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(!hasStarted)
        {

        }

        if(hasStarted)
        {
            if (enemiesPresent == enemyCount)
            {
                enemiesFinishedSpawning = true;
            }

            if (!enemiesFinishedSpawning)
            {
                SpawnEnemies();
            }
            score += scoreFactor;

            if (spawnInterval == 0)
            {
                spawnInterval = initialSpawnInterval;
                canSpawn = true;
            }
            spawnInterval--;

            if (enemiesSpawned == enemyCount && enemiesPresent == 0)
            {
                RoundChange();
            }
        }
    }

    public void StartGame()
    {
        hasStarted = true;
        waveCount = 1;
        enemyCount = 5;
    }

    public void OnDeath()
    {
        int finalScore = (int)Math.Floor(score);
    }

    public void RoundChange()
    {
        enemyCount = (int)(enemyCount * enemyIncreaseFactor);
        enemiesFinishedSpawning = false;
        waveCount++;
        initialSpawnInterval = (int)(initialSpawnInterval / 1.1);
    }

    public void SpawnEnemies()
    {
        for (int i = enemiesSpawned; i < enemyCount; i++)
        {
            if (canSpawn)
            {
                if (spawnInterval > 0)
                {
                    return;
                }
                int classNum = UnityEngine.Random.Range(0, enemyClasses.Length);
                EnemyController.CreateEnemy(enemyClasses[classNum], new Vector3(0, 0, 0));
                canSpawn = false;
                enemiesSpawned++;
            }
        }
    }
}
