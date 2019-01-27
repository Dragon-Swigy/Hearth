using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public Vector3 startOver = new Vector3(5, -20, 5);
    // Update is called once per frame

    void Update()
    {
        if(transform.localPosition.y <= startOver.y)
            SceneManager.LoadScene("Roll-A-Ball");
    }
}
