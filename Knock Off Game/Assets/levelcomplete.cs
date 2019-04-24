//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class levelcomplete : MonoBehaviour
{
    // Update is called once per frame
    public void LoadNextLevel ()
    {
        //score.text = "Your Score: " + scoreValue;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScoreScript.scoreValue = 0;
    }
}
