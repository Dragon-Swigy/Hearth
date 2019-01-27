using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OptionsMenu() //assign this to the "start" button
    {
        Debug.Log("Options!"); 
        SceneManager.LoadScene("OptionsMenu");
    }
  public void Victorian() //assign to Victorian House
    {
        Debug.Log("Victorian!");
        SceneManager.LoadScene("test2");
    }
    public void Cottage() //assign to Cottage
    {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("Cottage");
        
    }

    public void Mansion() //assign to Cottage
    {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("Mansion");

    }
    public void TrapHouse() //assign to Mansion
    {
        Debug.Log("Mansion!");
        SceneManager.LoadScene("TrapHouse");
    }
    public void Apartment() //assign to Mansion
    {
    
        SceneManager.LoadScene("Apartment");
    }

    public void MapScreen() //assign to Mansion
    {
        Debug.Log("Mansion!");
        SceneManager.LoadScene("MapScreen");
    }
}
