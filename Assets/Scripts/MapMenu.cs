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
        SceneManager.LoadScene("test1");
    }
  public void Victorian() //assign to Victorian House
    {
        Debug.Log("Victorian!");
        SceneManager.LoadScene("test2");
    }
    public void Cottage() //assign to Cottage
    {
        Debug.Log("Cottage!");
        SceneManager.LoadScene("test3");
    }
    public void Mansion() //assign to Mansion
    {
        Debug.Log("Mansion!");
        SceneManager.LoadScene("test4");
    }
}
