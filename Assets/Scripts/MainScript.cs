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
        /*
        trapHouse.interactable = !IsWin.Instance.trapHouseWin;
        apartmentHouse.interactable = !IsWin.Instance.apartmentWin;
        cottageHouse.interactable = !IsWin.Instance.cottageWin;
        mansionHouse.interactable = !IsWin.Instance.mansionWin;
        */
    }

    public void Victorian() //assign to Victorian House
    {
        Debug.Log("Victorian!");
        //SceneManager.LoadScene("test2");
    }

    public void Cottage() //assign to Cottage
    {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("Cottage");
    }

    public void Mansion() //assign to Cottage
    {
        Debug.Log("Mansion!");
        SceneManager.LoadScene("Mansion");
    }

    public void TrapHouse() //assign to Mansion
    {
        Debug.Log("TrapHouse!");
        SceneManager.LoadScene("TrapHouse");
    }

    public void Apartment() //assign to Mansion
    {
        Debug.Log("Apartment!");
        SceneManager.LoadScene("Apartment");
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
