using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameLauncher : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void MazeLaunch()
    {
        Debug.Log("Cottage!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Maze_Game");
    }

    public void PairLaunch()
    {
        Debug.Log("Cottage!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Pairs_Game");
    }

    public void RollABallLaunch()
    {
        Debug.Log("Cottage!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Roll-A-Ball");
    }


    public void Match3Launch()
    {
        Debug.Log("Match3!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Match3Game");
    }
}
