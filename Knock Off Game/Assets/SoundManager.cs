using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip gameOverSound, collectCoinSound, menuMusicSound, levelCompleteSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        gameOverSound = Resources.Load<AudioClip>("game over sound");
        collectCoinSound = Resources.Load<AudioClip>("coin sound");
        menuMusicSound = Resources.Load<AudioClip>("menu music");
        levelCompleteSound = Resources.Load<AudioClip>("level complete");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "game over sound":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "coin sound":
                audioSrc.PlayOneShot(collectCoinSound);
                break;
            case "menu music":
                audioSrc.PlayOneShot(menuMusicSound);
                break;
            case "level complete":
                audioSrc.PlayOneShot(levelCompleteSound);
                break;

        }
    }
    public static void StopMusic()
    {
        audioSrc.Stop();
    }
    public static void playMusic()
    {
        audioSrc.Play();
    }
}
