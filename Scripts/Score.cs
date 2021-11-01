using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float scoreCount;
    public Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 40;

    public bool isDead;
    public DeathMenu deathMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
            return;

        if (scoreCount >= scoreToNextLevel)
        {
            LevelUp();
        }
        scoreCount += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)scoreCount).ToString();
    }

    private void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
            return;
        

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }

    public void OnDead()
    {
        isDead = true;

        if(PlayerPrefs.GetFloat("HighScore") < scoreCount)
        PlayerPrefs.SetFloat("HighScore", scoreCount);

        deathMenu.ToggelEndMenu(scoreCount);
    }
}
