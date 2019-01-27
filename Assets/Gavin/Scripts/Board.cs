using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject[] blocks;

    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;

    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        setUp();
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
                GameObject dot = Instantiate(blocks[blockToUse], new Vector3(i, j, 0f), blocks[blockToUse].transform.rotation);
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + j + " )";
                allDots[i, j] = dot;
            }
        }
    }

}
