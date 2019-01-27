using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveToEnd : MonoBehaviour
{
    public void change_Scene()
    {
        Debug.Log("Hey I did a thing");
        SceneManager.LoadScene("Credits_Final");
    }
}
