using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Update()
    {
        LoadNextLevel();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        NextLevel nextLevel = FindObjectOfType<NextLevel>();

        if (nextLevel.nextLevel == true)
        {
            // new level
            int nextSeceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;

            if (nextSeceneIndex <= sceneIndex)
            {
                StartCoroutine(MyDelayedCode(nextSeceneIndex));
            }
            if (nextSeceneIndex > sceneIndex)
            {
                StartCoroutine(MyDelayedCode(0));
            }
        }
    }

    IEnumerator MyDelayedCode(int sceneIndex)
    {
        yield return new WaitForSeconds(1); // Wait for 1 second
        SceneManager.LoadScene(sceneIndex);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
