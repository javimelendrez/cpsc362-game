using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score; //The overall score during the game

    private void Awake()
    {
        if (instance == null)   //Assigns instance for the first time
        {
            instance = this;
        }
        else if (instance != this)  //Destroys if GameManager is a duplicate
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);  //Allows the GameManager to persist between scenes
    }
}
