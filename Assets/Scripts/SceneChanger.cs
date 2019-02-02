using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScreen");
    }
    
}
