using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Minigame : MonoBehaviour
{
    public void QuitMinigame ()
    {
        SceneManager.LoadScene("MapScreen");
    }
}

