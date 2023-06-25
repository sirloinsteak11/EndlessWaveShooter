using System;
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

    public int waveCount, lifeCount, enemyCount, enemiesPresent;
    [SerializeField] float score, scoreFactor;
    [SerializeField] internal bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        waveCount = 0;
        lifeCount = 3;
        hasStarted = false;
        startButton.onClick.AddListener(StartGame);
        changeRoundButtton.onClick.AddListener(RoundChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = Math.Floor(score).ToString();
        waveText.text = $"Wave: {waveCount}";
        lifeText.text = $"Lives: {lifeCount}";

        if(!hasStarted)
        {

        }

        if(hasStarted)
        {
            score += scoreFactor;
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
        enemyCount = (int)(enemyCount * 1.2);
        waveCount++;
    }
}
