using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickStart : MonoBehaviour
{
    TimeCheck TC;
    public Canvas canvasStart;
    public Canvas canvasMain;
    public Canvas canvasEnd;

    void Start()
    {
        TC = canvasMain.GetComponent<TimeCheck>();
        canvasStart.enabled = true;
        canvasMain.enabled = false;
        canvasEnd.enabled = false;
    }

    public void OnClickStartButton()
    {
        canvasStart.enabled = false;
        canvasMain.enabled = true;
        canvasEnd.enabled = false;
        for (int i = 0; i < TC.PosNum; i++)
        {
            GameObject Temp = Instantiate(TC.NNPC, TC.Position[i].transform.position, Quaternion.identity);
        }
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
