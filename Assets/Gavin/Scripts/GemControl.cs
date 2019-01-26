using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : MonoBehaviour
{
    public MiniGameFlow miniGameFlow;
    public int row;
    public int col;

    void OnMouseDown()
    {
        if (MiniGameFlow.lockDelay == "n") {
            MiniGameFlow.destroyedGemX = transform.position.x;
            miniGameFlow.findCombo(this);
            //MiniGameFlow.lockDelay = "y";
        }
    }

  
}
