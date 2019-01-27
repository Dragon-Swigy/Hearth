using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject[] blocks;
    public Text countText;
    public bool uhh = false;

    public Image youWin;
    public Button backButton;

    private int count;

    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;

    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        setUp();

        count = 0;
        countText.text = "Score: " + count.ToString();

        backButton.gameObject.SetActive(false);
        youWin.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (uhh)
        {
            winCon();
        }
    }

    private void setUp()
    {
        for (int i = 0;i < width; i++) 
        {
            for (int j = 0; j < height; j++)
            {
                GameObject backgroundTile = Instantiate(tilePrefab,new Vector3(i,j,1.5f), tilePrefab.transform.rotation) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";

                int blockToUse = Random.Range(0, blocks.Length);
                int maxIterations = 0;
                while(matchesAt(i, j, blocks[blockToUse]) && maxIterations < 100)
                {
                    blockToUse = Random.Range(0, blocks.Length);
                    maxIterations++;
                }
                maxIterations = 0;

                GameObject dot = Instantiate(blocks[blockToUse], new Vector3(i, j, 0f), blocks[blockToUse].transform.rotation);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + j + " )";
                allDots[i, j] = dot;
            }
        }
    }

    private bool matchesAt(int column, int row, GameObject piece)
    {
        if (column > 1 && row > 1)
        {
            if(allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
            {
                return true;
            }
        }
        else if (column <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (allDots[column, row - 1].tag == piece.tag && allDots[column, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void destroyMatchesAt(int column, int row)
    {
        if (allDots[column, row].GetComponent<GemControl>().isMatched)
        {
            Destroy(allDots[column, row]);
            count++;
            countText.text = "Score: " + count.ToString();
            if (count >= 3)
            {
                uhh = true;
            }
            allDots[column, row] = null;
        }
    }

    public void destroyMatches()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null && !uhh)
                {
                    destroyMatchesAt(i, j);
                }
            }
        }
        StartCoroutine(decreaseRowCo());
    }

    private IEnumerator decreaseRowCo()
    {
        int nullCount = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(allDots[i, j] == null)
                {
                    nullCount++;
                }
                else if(nullCount > 0)
                {
                    allDots[i, j].GetComponent<GemControl>().row -= nullCount;
                    allDots[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.4f);
        StartCoroutine(fillBoardCo());
    }

    private void refillBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(allDots[i, j] == null)
                {
                    int blockToUse = Random.Range(0, blocks.Length);
                    GameObject piece = Instantiate(blocks[blockToUse], new Vector3(i, j, 0f), blocks[blockToUse].transform.rotation);
                    allDots[i, j] = piece;
                }
            }
        }
    }

    private bool matchesOnBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(allDots[i, j] != null)
                {
                    if (allDots[i, j].GetComponent<GemControl>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private IEnumerator fillBoardCo()
    {
        refillBoard();
        yield return new WaitForSeconds(.5f);

        int maxIterations = 0;
        while (matchesOnBoard() && maxIterations < 100)
        {
            yield return new WaitForSeconds(.5f);
            destroyMatches();
            maxIterations++;
        }
        maxIterations = 0;
    }

    void winCon()
    {
        if (uhh)
        {
            IsWin.Instance.AddWin();
            IsWin.Instance.mansionWin = true;
            youWin.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            Debug.Log("Kill me.");
        }
    }
}