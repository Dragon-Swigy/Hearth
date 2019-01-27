using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame () //assign this to the "start" button
    {
        SceneManager.LoadScene("MapScreen");
    }

    public void QuitGame() //assign this to the "log out" button
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
