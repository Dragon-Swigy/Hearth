using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsWin : MonoBehaviour
{
    // Start is called before the first frame update

    //places visited
    //disable them after visit
    //dialogue played
    //add to win counter
    //When wincount = 4 cue Choicce scene
    public bool trapHouseWin = false;
    public bool cottageWin = false;
    public bool mansionWin = false;
    public bool apartmentWin = false;
    public int winCount = 0;
    public bool startup = false;
    public int x;

    private static IsWin  m_instance;

    public static IsWin Instance
    {
        get
        {
            return m_instance;
        }
    }

    public static int m_referenceCount = 0;

    void Awake()
    {
        DontDestroyOnLoad(this  );

        m_referenceCount++;
        if (m_referenceCount > 1)
        {
            Debug.LogError("Two Game Managers!");
            DestroyImmediate(this.gameObject);
            return;
        }

        m_instance = this;
        

    }

    public void startOver()
    {
            trapHouseWin = false;
            cottageWin = false;
            mansionWin = false;
            apartmentWin = false;
            winCount = 0;
    }

    private void OnDestroy()
    {
        m_referenceCount--;
        if (m_referenceCount == 0)
        {
            m_instance = null;
        }
    }
    
    public void AddWin()
    {
        winCount++;
    }
    public void Mansion()
    {
        winCount--;
    }
    // Update is called once per frame
    void Update()
    {
        if (mansionWin&&trapHouseWin&&apartmentWin&&cottageWin)
        {
            winCount += 1;
        }

        if (winCount ==  4)
        {
            Debug.Log("YEET");
            SceneManager.LoadScene("Choice");
           
        }
    }
}
