using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Loadmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        SoundManager.PlaySound("menu music");
        //adding line to reset score counter
        ScoreScript.scoreValue = 0;
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
