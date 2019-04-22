
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    /*public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("testScene");
    }
    public void doesplay(string testScene)
    {
        SceneManager.LoadScene("testScene", LoadSceneMode.Additive);
        Debug.Log("testScene" + testScene);
        SceneManager.LoadScene(testScene);
    }*/
    public void Startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}