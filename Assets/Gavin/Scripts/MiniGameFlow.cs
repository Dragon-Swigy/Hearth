using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameFlow : MonoBehaviour
{
    public GemControl[,] grid = new GemControl[9,9];

    public Transform[] blocks;
    public List<GameObject> hor;
    public List<GameObject> ver;

    private int randomIndex;
    private int randomIndex2;

    public static float destroyedGemX = -10;
    public static string lockDelay = "n";

    // Start is called before the first frame update
    void Start()
    {
        for (int rowNum = 6; rowNum < 15; rowNum++)
        {
            for (int colNum = -4; colNum < 5; colNum++)
            {
                randomIndex = Random.Range(0, 5);
                Debug.Log(rowNum);
                Debug.Log(colNum);
                grid[rowNum-6, colNum+4] = Instantiate(blocks[randomIndex], new Vector3(colNum, rowNum, 0), blocks[randomIndex].rotation).GetComponent<GemControl>();
                grid[rowNum - 6, colNum + 4].miniGameFlow = this;
                grid[rowNum - 6, colNum + 4].row = rowNum - 6;
                grid[rowNum - 6, colNum + 4].col = colNum+4;
            }
        }
    }

    void Update()
    {
        /*if (destroyedGemX != -10)
        {
            randomIndex2 = Random.Range(0,5);
            Instantiate(blocks[randomIndex2], new Vector3(destroyedGemX, 12, 0), blocks[randomIndex2].rotation);
            destroyedGemX = -10;
            StartCoroutine(resetDelay());
        }*/
    }

    public void findCombo(GemControl gem)
    {
        int tempGreater = 0;
        int tempLesser = 0;
        int tempLower = 0;
        int tempHigher = 0;
        hor.Add(gem.gameObject);
        for (int i = gem.col+1; i < 9; i++)
        {
            if (grid[gem.row, i] != null && grid[gem.row,i].GetComponent<Renderer>().material.color == gem.GetComponent<Renderer>().material.color)
            {
                hor.Add(grid[gem.row, i].gameObject);
                tempGreater = i;
            }
            else
            {
                break;
            }
        }
        for (int i = gem.col-1; i > -1; i--)
        {
            if (grid[gem.row, i] != null && grid[gem.row, i].GetComponent<Renderer>().material.color == gem.GetComponent<Renderer>().material.color)
            {
                hor.Add(grid[gem.row, i].gameObject);
                tempLesser = i;
            }
            else
            {
                break;
            }
        }

        ver.Add(grid[gem.row, gem.col].gameObject);
        for (int i = gem.row+1; i < 9; i++)
        {
            if (grid[i, gem.col] && grid[i, gem.col].GetComponent<Renderer>().material.color == gem.GetComponent<Renderer>().material.color)
            {
                ver.Add(grid[i, gem.col].gameObject);
                tempHigher = i;
            }
            else
            {
                break;
            }
        }
        for (int i = gem.row-1; i > -1; i--)
        {
            if (grid[i, gem.col] && grid[i, gem.col].GetComponent<Renderer>().material.color == gem.GetComponent<Renderer>().material.color)
            {
                ver.Add(grid[i, gem.col].gameObject);
                tempLower = i;
            }
            else
            {
                break;
            }
        }

        if (hor.Count >= 3)
        {
            ver.Remove(gem.gameObject);

            for (int i = 0; i < hor.Count; i++)
            {
                Destroy(hor[i]);
            }
            reIndexRow(gem.row, tempGreater, tempLesser);
        }

        if (ver.Count >= 3)
        {
            for (int i = 0; i < ver.Count; i++)
            {
                Destroy(ver[i]);
            }
            reIndexCol(gem.col, tempHigher, tempLower);
        }
    }

    void reIndexRow(int row, int tempHigher, int tempLower)
    {
        for (int j = tempLower; j <= tempHigher; j++)
        {
            for (int i = row; i < 9; i++)
            {
                if (grid[i, (j + 1)] == null)
                {
                    break;
                }
                else
                {
                    grid[i, j] = grid[i,(j + 1)];
                    grid[i, (j + 1)] = null;
                }
            }
        }
    }
    void reIndexCol(int tempLower, int tempGreater, int tempLesser)
    {
        for (int row = tempLower; row > 0; row--)
        {
            grid[row, tempLower] = grid[(tempGreater - tempLesser) + row, tempLower];
        }
    }

    IEnumerator resetDelay()
    {
        yield return new WaitForSeconds(2);
        lockDelay = "n";
    }

}
