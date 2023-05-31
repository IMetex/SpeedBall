using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool nextLevel;
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && GameManager.GameManagerInstance.gameOver == false)
        {
            nextLevel = true;
            GameManager.GameManagerInstance.winPanel.SetActive(true); // show the game over panel
            GameManager.GameManagerInstance.gameoverPanel.SetActive(false); // not show the game over panel
            GameManager.GameManagerInstance.gameState = true;
            other.gameObject.SetActive(false);

            // UI panel show deacttive
        }
    }
}
