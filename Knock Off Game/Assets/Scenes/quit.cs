using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    public void doesquit()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}