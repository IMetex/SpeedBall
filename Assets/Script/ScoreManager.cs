using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public int scoreAmount;
    public Text scoreText;
    public Text highScoreText;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        UpdateHighScore(score);
    }

    public void UpdateHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateHighScore(score);
    }
}

