using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public Text Win_Text;
    public Button Return;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Win_Text.text = "";
        Return.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {


        float move_Horizontal = Input.GetAxis("Horizontal");
        float move_Vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(move_Horizontal, 0f, move_Vertical) * Time.deltaTime * speed);        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Win_Text.text = "You Win!!!?";
            Return.gameObject.SetActive(true);
            GameObject.Find("Return").GetComponentInChildren<Text>().text = "la di da";

        }
    }
}
