using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Housepick : MonoBehaviour
{
    // Start is called before the first frame update
    public void buyApartment()
    { 
        Debug.Log("Options!");
        SceneManager.LoadScene("ApartmentEnd");
    }
    public void buyCottage() 
    {
        Debug.Log("Options!");
        SceneManager.LoadScene("CottageEnd");
    }
    public void buyMansion()
    {
        Debug.Log("Options!");
        SceneManager.LoadScene("MansionEnd");
    }
    public void buyTraphouse() 
    {
        Debug.Log("Options!");
        SceneManager.LoadScene("TrapEnd");
    }
}
