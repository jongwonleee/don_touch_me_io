using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickStart : MonoBehaviour
{
    public Canvas canvasStart;
    public Canvas canvasMain;
    public Canvas canvasEnd;

    void Start()
    {
        canvasStart.enabled = true;
        canvasMain.enabled = false;
        canvasEnd.enabled = false;
    }

    public void OnClickStartButton()
    {
        canvasStart.enabled = false;
        canvasMain.enabled = true;
        canvasEnd.enabled = false;
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
