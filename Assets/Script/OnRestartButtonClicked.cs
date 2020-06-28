using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OnRestartButtonClicked : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvasStart;
    public Canvas canvasMain;
    public Canvas canvasEnd;
    TimeCheck TC;
    ItemSpawning IS;
    void Start()
    {
        TC = canvasMain.GetComponent<TimeCheck>();
        IS = canvasMain.GetComponent<ItemSpawning>();
        FileStream f = new FileStream("Assets/Resources/Text/Restart.txt", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader reader = new StreamReader(f, System.Text.Encoding.Unicode);
        string str = reader.ReadLine();

        if (str.Equals("true"))
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
        else
        {
            canvasStart.enabled = true;
            canvasMain.enabled = false;
            canvasEnd.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnApplicationQuit()
    {
        FileStream f = new FileStream("Assets/Resources/Text/Restart.txt", FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine("false");
        writer.Close();
        f.Close();
    }
}