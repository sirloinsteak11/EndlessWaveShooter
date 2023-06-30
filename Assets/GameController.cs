using System;
using System.Threading;
using System.Threading.Tasks;
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
    [SerializeField] GameObject gameOverText;

    public EnemyController EnemyController;
    public Transform[] enemySpawnLocations;

    public int waveCount, lifeCount, enemyCount, enemiesPresent, enemiesSpawned;
    [SerializeField] float score, scoreFactor, enemyIncreaseFactor;
    [SerializeField] internal bool hasStarted, enemiesFinishedSpawning, canSpawn, hasPickedPowerup;
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
            }
            score += scoreFactor;

            if (spawnInterval == 0)
            {
                //spawnInterval = initialSpawnInterval;
                canSpawn = true;
            }
            spawnInterval--;

            if (enemiesSpawned == enemyCount && enemiesPresent == 0)
            {
                RoundChange();
            }

            if (lifeCount < 1)
            {
                hasStarted = false;
                OnDeath();
            }
        }
    }

    public void StartGame()
    {
        hasStarted = true;
        waveCount = 1;
        enemyCount = 5;
        SpawnEnemies();
    }

    public void OnDeath()
    {
        int finalScore = (int)Math.Floor(score);
        gameOverText.SetActive(true);
    }

    public void RoundChange()
    {
        enemyCount = (int)(enemyCount * enemyIncreaseFactor);
        enemiesFinishedSpawning = false;
        waveCount++;
        initialSpawnInterval = (int)(initialSpawnInterval / 1.1);
        spawnInterval = initialSpawnInterval;
        EnemyController.spawnInterval /= 1.1f;
        enemiesSpawned = 0;
        lifeCount++;
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        // 5 enemies
        if (waveCount == 1)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, enemyCount));
        }

        // 6 enemies
        if (waveCount == 2)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 1));
        }

        // 7 enemies
        if (waveCount == 3)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 2));
        }

        // 8 enemies
        if (waveCount == 4)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 4));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 3));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 1));
        }

        // 9 enemies
        if (waveCount == 5)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 4));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 3));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 2));
        }

        // 10 enemies
        if (waveCount == 6)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 3));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 4));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 3));
        }

        // 12 enemies
        if (waveCount == 7)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 3));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 4));
        }

        // 14 enemies
        if (waveCount == 8)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 4));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 5));
        }

        // 16 enemies
        if (waveCount == 9)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 6));
        }

        // 19 enemies
        if (waveCount == 10)
        {
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 5));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 3));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 2));
            StartCoroutine(EnemyController.CreateEnemy("eliteHeavy", enemySpawnLocations, 1));
            StartCoroutine(EnemyController.CreateEnemy("medium", enemySpawnLocations, 4));
            StartCoroutine(EnemyController.CreateEnemy("elite", enemySpawnLocations, 2));
            StartCoroutine(EnemyController.CreateEnemy("weak", enemySpawnLocations, 2));
        }
    }
}
