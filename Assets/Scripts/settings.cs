using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour
{
    public AudioMixer audioMix;

    public void SetVolume(float volume)
    {
        audioMix.SetFloat("Volume", volume);
    }

    public void Return() //assign this to the "start" button
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame() //assign this to the "log out" button
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
