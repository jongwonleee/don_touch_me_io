using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvasMain;
    public Canvas canvasStart;
    public Canvas canvasEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        canvasStart.enabled = false;
        canvasEnd.enabled = false;
    }

    public void OnClickRestartButton()
    {

    }
}
