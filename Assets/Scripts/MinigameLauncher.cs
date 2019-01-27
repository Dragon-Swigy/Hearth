using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameLauncher : MonoBehaviour
{
    public void MazeLaunch()
   {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("Maze_Game");
        
    }

    public void PairLaunch()
    {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("Pairs_Game");

    }
}
