using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public bool gameState;
    public bool gameOver;

    [Header("UI references :")]
    public GameObject scoreText;
    public GameObject highScoreText;
    public GameObject menuPanel;
    public GameObject gameoverPanel;
    public GameObject winPanel;

    void Start()
    {
        gameState = false;
        GameManagerInstance = this;
    }

    public void StartTheGame()
    {
        gameState = true;
        menuPanel.SetActive(false);
        scoreText.SetActive(true);
        highScoreText.SetActive(false);
        GameObject.FindWithTag("particle").GetComponent<ParticleSystem>().Play();
    }

    public void GameOver()
    {
        gameOver = true;
        gameoverPanel.SetActive(true);
    }
    
    public void NextLevel()
    {

    }
}
