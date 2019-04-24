using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    /*
     *     bool gameHasEnded = false;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", 2f);
            Restart();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreScript.scoreValue = 0;
    }
     */
    public static bool GameIsOver = false;
    public GameObject gameOverMenuUI;
    public float restartDelay = 1f;
    public GameObject completLevelUI;

    public void CompleteLevel()
    {
        completLevelUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {

            EndGame();
        }
    }
    public void EndGame()
    {
        gameOverMenuUI.SetActive(true);
        //SoundManager.StopMusic();
        Time.timeScale = 0f;
        GameIsOver = true;
       

    }
    public void RestartButton()
    {
        Restart();
    }
    void Restart()
    {
        gameOverMenuUI.SetActive(false);
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        ScoreScript.scoreValue = 0;
    }
}
