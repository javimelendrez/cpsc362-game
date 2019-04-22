using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float startingTime = 40;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        startingTime -= Time.deltaTime;

        timerText.text = "" + Mathf.Round(startingTime) + "s";
        if (startingTime <= 0)
        {
            ScoreScript.scoreValue = 0;
            SoundManager.StopMusic();
            SoundManager.PlaySound("game over sound");
            FindObjectOfType<GameManage>().EndGame();
        }
    }
}
