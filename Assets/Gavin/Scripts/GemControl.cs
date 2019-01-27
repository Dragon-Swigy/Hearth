using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemControl : MonoBehaviour
{
    private Board board;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    private GameObject otherDot;

    private float minSize = 40;
    private float maxSize = 50;
    private float speed = 1.0f;

    [Header("Board Variables")]
    public float swipAngle = 0f;
    public float swipeResist = 1f;
    public int column;
    public int row;
    public int previousColumn, previousRow;
    public int targetX, targetY;
    public bool isMatched = false;

    void Start()
    {
        board = FindObjectOfType<Board>();
        targetX = (int)transform.position.x;
       targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
        previousRow = row;
        previousColumn = column;
    }

    private void Update()
    {

        float range = maxSize - minSize;
        Vector3 heck = transform.localScale;
        heck.x = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f * range + minSize;
        heck.y = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f * range + minSize;
        heck.z = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f * range + minSize;
        transform.localScale = heck;

        findMatches();
        if (isMatched)
        {
            Renderer mySprite = GetComponent<Renderer>();
            mySprite.material.color = new Color(1f, 1f, 1f, .2f);
        }
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > .1) //Move Towards the Target
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
        }
        else //Directly set the Position
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
        }
        if (Mathf.Abs(targetY - transform.position.y) > .1) //Move Towards the Target
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
        }
        else //Directly set the Position
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
        }
    }

    public IEnumerator checkMoveCo()
    {
        yield return new WaitForSeconds(.5f);
        if (otherDot != null)
        {
            if (!isMatched && !otherDot.GetComponent<GemControl>().isMatched)
            {
                otherDot.GetComponent<GemControl>().row = row;
                otherDot.GetComponent<GemControl>().column = column;

                row = previousRow;
                column = previousColumn;
            }
            else
            {
                board.destroyMatches();
            }
            otherDot = null;
        }
    }

    void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-11));
        //Debug.Log(firstTouchPosition);
    }

    void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -11));
        calculateAngle();
    }

    void calculateAngle()
    {
        if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist)
        {
            swipAngle = Mathf.Atan2((finalTouchPosition.y - firstTouchPosition.y), (finalTouchPosition.x - firstTouchPosition.x)) * 180 / Mathf.PI;
            //Debug.Log(swipAngle);
            movePieces();
        }
    }

    void movePieces()
    {
        if (swipAngle > -45 && swipAngle <= 45 && column < board.width - 1) //Right Swipe
        {
            otherDot = board.allDots[column + 1, row];
            previousColumn = column;
            previousRow = row;
            otherDot.GetComponent<GemControl>().column -= 1;
            column += 1;
        }
        else if (swipAngle > 45 && swipAngle <= 135 && row < board.height - 1) //Up Swipe
        {
            otherDot = board.allDots[column, row + 1];
            previousColumn = column;
            previousRow = row;
            otherDot.GetComponent<GemControl>().row-= 1;
            row += 1;
        }
        else if ((swipAngle > 135 || swipAngle <= -135) && column > 0) //Left Swipe
        {
            otherDot = board.allDots[column - 1, row];
            previousColumn = column;
            previousRow = row;
            otherDot.GetComponent<GemControl>().column += 1;
            column -= 1;
        }
        else if (swipAngle < -45 && swipAngle >=-135 && row > 0) //Down Swipe
        {
            otherDot = board.allDots[column, row - 1];
            previousColumn = column;
            previousRow = row;
            otherDot.GetComponent<GemControl>().row += 1;
            row -= 1;
        }
        StartCoroutine(checkMoveCo());
    }

    void findMatches()
    {
        if (column > 0 && column < board.width - 1)
        {
            GameObject leftDot1 = board.allDots[column - 1, row];
            GameObject rightDot1 = board.allDots[column + 1, row];
            if (leftDot1 != null && rightDot1 != null) {
                if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag)
                {
                    leftDot1.GetComponent<GemControl>().isMatched = true;
                    rightDot1.GetComponent<GemControl>().isMatched = true;
                    isMatched = true;
                }
            }
        }
        if (row > 0 && row < board.height - 1)
        {
            GameObject upDot1 = board.allDots[column, row + 1];
            GameObject downDot1 = board.allDots[column, row - 1];
            if (upDot1 != null && downDot1 != null)
            {
                if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag)
                {
                    upDot1.GetComponent<GemControl>().isMatched = true;
                    downDot1.GetComponent<GemControl>().isMatched = true;
                    isMatched = true;
                }
            }
        }
    }
}