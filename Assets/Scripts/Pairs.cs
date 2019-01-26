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

    public Button Return;
    public Image YouWin;

    private bool card1Uncovered = false;
    private bool card2Uncovered = false;
    private bool card3Uncovered = false;
    private bool card4Uncovered = false;

    private bool m1 = false;
    private bool m2 = false;

    private int uncovered;

    void Start()
    {
        uncovered = 0;

        Return.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        matched();
        win();
        reset();
    }

    public void uncoverCard1()
    {
        Card1.gameObject.SetActive(false);
        card1Uncovered = true;
        uncovered++;
    }

    public void uncoverCard2()
    {
        Card2.gameObject.SetActive(false);
        card2Uncovered = true;
        uncovered++;
    }

    public void uncoverCard3()
    {
        Card3.gameObject.SetActive(false);
        card3Uncovered = true;
        uncovered++;
    }

    public void uncoverCard4()
    {
        Card4.gameObject.SetActive(false);
        card4Uncovered = true;
        uncovered++;
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
                //reset();
            }
        }
        if(!m2)
        {
            if(card2Uncovered && card4Uncovered)
        {
                Destroy(Card2.gameObject);
                Destroy(Card4.gameObject);

                uncovered = 0;
                m2 = true;
                //reset();
            }
        }
    }
    

    public void reset()
    {
        if(uncovered > 1)
        {
            Card1.gameObject.SetActive(true);
            Card2.gameObject.SetActive(true);
            Card3.gameObject.SetActive(true);
            Card4.gameObject.SetActive(true);

            card1Uncovered = false;
            card2Uncovered = false;
            card3Uncovered = false;
            card4Uncovered = false;

            uncovered = 0;
        }
    }

    public void win()
    {
        Debug.Log(m1);
        Debug.Log(m2);
        if(m1 && m2)
        {
            Return.gameObject.SetActive(true);
            YouWin.gameObject.SetActive(true);
        }
    }

}
