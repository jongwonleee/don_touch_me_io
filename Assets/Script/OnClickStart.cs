using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class OnClickStart : MonoBehaviour
{
    TimeCheck TC;
    ItemSpawning IS;
    public Canvas canvasStart;
    public Canvas canvasMain;
    public Canvas canvasEnd;

    void Start()
    {
        IS = canvasMain.GetComponent<ItemSpawning>();
        TC = canvasMain.GetComponent<TimeCheck>();
        //canvasStart.enabled = true;
        //canvasMain.enabled = false;
        //canvasEnd.enabled = false;
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
        for (int i = 0; i < 8; i++)
            IS.CreateItem();
    }

    public void OnClickRestartButton()
    {
        FileStream f = new FileStream("Restart.dat", FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine("true");
        writer.Close();
        f.Close();
        SceneManager.LoadScene("SampleScene");

    }
}
