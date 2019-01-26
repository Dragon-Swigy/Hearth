using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameFlow : MonoBehaviour
{

    public Transform[] blocks;

    private int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        for (int rowNum = 6; rowNum < 16; rowNum++)
        {
            for (int colNum = -4; colNum < 5; colNum++)
            {
                randomIndex = Random.Range(0, 5);

                Instantiate(blocks[randomIndex], new Vector3(colNum, rowNum, 0), blocks[randomIndex].rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
