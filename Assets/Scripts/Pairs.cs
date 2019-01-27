using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pairs : MonoBehaviour
{
    public Button Card1;
    public Button Card2;
    public Button Card3;
    public Button Card4;
    public Button Card5;
    public Button Card6;

    public Button Return;
    public Image YouWin;
    public Text clickCount;
    public Image YouLose;

    private bool card1Uncovered = false;
    private bool card2Uncovered = false;
    private bool card3Uncovered = false;
    private bool card4Uncovered = false;
    private bool card5Uncovered = false;
    private bool card6Uncovered = false;

    private bool m1 = false;
    private bool m2 = false;
    private bool m3 = false;
    private bool gameOver = false;
    private bool winGame = false;

    private int uncovered;
    private int counter;
    public int wimCheck;

    void Start()
    {
        m1 = false;
        m2 = false;
        m3 = false;
        uncovered = 0;
        counter = 12;
        clickCount.text = "";

        Return.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(false);
        YouLose.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        SetCountText();
        matched();
        win();
        reset();
        lose();
    }

    public void Count()
    {
        if(!gameOver)
        {
            counter--;
        }
    }

    public void uncoverCard1()
    {
        if(!gameOver)
        {
            Card1.gameObject.SetActive(false);
            card1Uncovered = true;
            uncovered++;
        }
        
    }

    public void uncoverCard2()
    {
        if (!gameOver)
        {
            Card2.gameObject.SetActive(false);
            card2Uncovered = true;
            uncovered++;
        }
            
    }

    public void uncoverCard3()
    {
        if (!gameOver)
        {
            Card3.gameObject.SetActive(false);
            card3Uncovered = true;
            uncovered++;
        }
            
    }

    public void uncoverCard4()
    {
        if (!gameOver)
        {
            Card4.gameObject.SetActive(false);
            card4Uncovered = true;
            uncovered++;
        }
            
    }

    public void uncoverCard5()
    {
        if (!gameOver)
        {
            Card5.gameObject.SetActive(false);
            card5Uncovered = true;
            uncovered++;
        }
            
    }

    public void uncoverCard6()
    {
        if (!gameOver)
        {
            Card6.gameObject.SetActive(false);
            card6Uncovered = true;
            uncovered++;
        }
            
    }

    public void matched()
    {
        if(!m1)
        {
            if (card1Uncovered && card3Uncovered)
            {

                Destroy(Card1.gameObject);
                Destroy(Card3.gameObject);

                uncovered = 0;
                m1 = true;
                reset();
            }
        }

        if (!m2)
        {
            if(card2Uncovered && card4Uncovered)
            {
                Debug.Log(card4Uncovered);
                Debug.Log(card2Uncovered);
                Destroy(Card2.gameObject);
                Destroy(Card4.gameObject);

                uncovered = 0;
                m2 = true;
                reset();
            }
        }
        
        if(!m3)
        {
            if(card6Uncovered && card5Uncovered)
            {
                Debug.Log(card5Uncovered);
                Debug.Log(card6Uncovered);
                Destroy(Card5.gameObject);
                Destroy(Card6.gameObject);

                uncovered = 0;
                m3 = true;
                reset();
            }
        }
    }
    

    public void reset()
    {
        if(uncovered == 2)
        {
            if(Card1 != null)
            {
                Card1.gameObject.SetActive(true);
            }

            if (Card2 != null)
            {
                Card2.gameObject.SetActive(true);
            }
            if (Card3 != null)
            {
                Card3.gameObject.SetActive(true);
            }
            if (Card4 != null)
            {
                Card4.gameObject.SetActive(true);
            }
            if (Card5 != null)
            {
                Card5.gameObject.SetActive(true);
            }
            if (Card6 != null)
            {
                Card6.gameObject.SetActive(true);
            }


            card1Uncovered = false;
            card2Uncovered = false;
            card3Uncovered = false;
            card4Uncovered = false;
            card5Uncovered = false;
            card6Uncovered = false;

            uncovered = 0;
        }
    }

    void SetCountText()
    {
        clickCount.text = "Clicks left: " + counter.ToString();
    }

    public void win()
    {
        if (!winGame)
        {
            
            //Debug.Log(m1);
            //Debug.Log(m2);
            if (m1 && m2 && m3)
            {
                IsWin.Instance.AddWin();
                Return.gameObject.SetActive(true);
                YouWin.gameObject.SetActive(true);
                winGame = true;
            }
        }
        
    }

    public void lose()
    {
        if(counter == 0)
        {
            YouLose.gameObject.SetActive(true);
            Return.gameObject.SetActive(true);

            gameOver = true;
        }
    }

}
