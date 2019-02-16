using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public Button trapHouse;
    public Button apartmentHouse;
    public Button cottageHouse;
    public Button mansionHouse;

    void Update()
    {
        trapHouse.interactable = !IsWin.Instance.trapHouseWin;
        apartmentHouse.interactable = !IsWin.Instance.apartmentWin;
        cottageHouse.interactable = !IsWin.Instance.cottageWin;
        mansionHouse.interactable = !IsWin.Instance.mansionWin;
    }

    public void Victorian() //assign to Victorian House
    {
        Debug.Log("Victorian!");
        //SceneManager.LoadScene("test2");
    }

    public void Cottage() //assign to Cottage
    {
        Debug.Log("Cottage!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Maze_Game");
    }

    public void Mansion() //assign to Cottage
    {
        Debug.Log("Mansion!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Match3Game");
    }

    public void TrapHouse() //assign to Mansion
    {
        Debug.Log("TrapHouse!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Roll-A-Ball");
    }

    public void Apartment() //assign to Mansion
    {
        Debug.Log("Apartment!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Pairs_Game");
    }

    public void GothHouse()
    {
        Debug.Log("GothLady!");
        //SceneManager.LoadScene("reeeeee");
    }

    public void QuitGame() //assign this to the "log out" button
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
