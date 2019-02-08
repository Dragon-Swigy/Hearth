using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    private float timeDown;
    public Button Return;
    public Image YouWin;
    public Image YouLose;

    public Text timerText;
    private float startTime;    

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Maze_Start");
        startTime = 120;
        timeDown = startTime;
        
        rb = GetComponent<Rigidbody>();

        Return.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(false);
        YouLose.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (timeDown >= 0)
        {
            timeDown -= Time.deltaTime;

            string seconds = (timeDown % 120).ToString("f0");

            timerText.text = seconds;
        }
        else
        {
            lose();
        }
        

        float move_Horizontal = Input.GetAxis("Horizontal");
        float move_Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(-move_Vertical, 0f, move_Horizontal) * Time.deltaTime * speed);

    }

    public void lose()
    {
        Return.gameObject.SetActive(true);
        timerText.color = Color.black;
        YouLose.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            IsWin.Instance.AddWin();
            IsWin.Instance.cottageWin = true;
            Time.timeScale = 0f;
            Return.gameObject.SetActive(true);
            YouWin.gameObject.SetActive(true);
        }
    }
}
