using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class credits_Final : MonoBehaviour
{
    public void change_Scene()
    {
        Debug.Log("Hey I did a thing");
        SceneManager.LoadScene("Final");
    }

    public void to_Credit()
    {
        Debug.Log("dumb");
        SceneManager.LoadScene("Credits_Final");
    }
}
