using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public Button Return;
    public Image YouWin;
    public Image YouLose;

    public Text timerText;
    private float startTime;
    private bool end = false;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        startTime = 60;

        Return.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(false);
        YouLose.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float t = -Time.time + startTime;

        string seconds = (t % 60).ToString("f0");

        timerText.text = seconds;
        

        float move_Horizontal = Input.GetAxis("Horizontal");
        float move_Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(-move_Vertical, 0f, move_Horizontal) * Time.deltaTime * speed);

        if (t == 0)
        {
            lose();
        }
    }

    public void lose()
    {
        Return.gameObject.SetActive(true);
        timerText.color = Color.red;
        YouLose.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            Return.gameObject.SetActive(true);
            YouWin.gameObject.SetActive(true);

        }
    }
}
