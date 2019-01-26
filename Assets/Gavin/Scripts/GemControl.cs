using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (MiniGameFlow.lockDelay == "n") {
            MiniGameFlow.destroyedGemX = transform.position.x;
            Destroy(gameObject);
            MiniGameFlow.lockDelay = "y";
        }
    }
}
