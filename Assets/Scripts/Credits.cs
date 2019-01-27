using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame() //assign this to the "log out" button
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
