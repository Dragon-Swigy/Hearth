using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public Button Return;
    public Image YouWin;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Return.gameObject.SetActive(false);
        YouWin.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {


        float move_Horizontal = Input.GetAxis("Horizontal");
        float move_Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(-move_Vertical, 0f, move_Horizontal) * Time.deltaTime * speed);        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Return.gameObject.SetActive(true);
            YouWin.gameObject.SetActive(true);
        }
    }
}
