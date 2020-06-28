using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCheck : MonoBehaviour
{
    float Timecnt;
    float NPCRegen;
    string Timestr;

    int random;

    public int PosNum;

    public Canvas canvasMain;

    public Text CurrentRecord;
    public Text CurrentScore;

    public GameObject NNPC;
    public GameObject FNPC;
    public GameObject CNNPC;
    public GameObject CSNPC;

    public GameObject[] Position;

    void Awake()
    {
        Timecnt = 0.0f;
        NPCRegen = 0.0f;
        Timestr = "";
        random = 0;
    }

    void Update()
    {
        if (canvasMain.enabled == true)
        {
            FlowOfTime();
            ShowTime(CurrentRecord);
            CreateNPC();
        }
        else
            ShowTime(CurrentScore);
    }

    void FlowOfTime()
    {
        Timecnt += Time.deltaTime;
        NPCRegen += Time.deltaTime;
        Timestr = Timecnt.ToString("N2");
        Timestr.Replace(".", ":");
    }

    void ShowTime(Text t)
    {
        t.text = Timestr;
    }

    void CreateNPC()
    {    
        if (NPCRegen >= 5.0f && Timecnt <= 20.0f)
        {
            NPCRegen -= 5.0f;
            for (int i = 0; i < PosNum; i++)
            {
                GameObject Temp = Instantiate(NNPC, Position[i].transform.position, Quaternion.identity);
            }
        }
        else if (NPCRegen >= 5.0f && Timecnt <= 40.0f)
        {
            NPCRegen -= 5.0f;
            for (int i = 0; i < PosNum; i++)
            {
                GameObject Temp = Instantiate(FNPC, Position[i].transform.position, Quaternion.identity);
            }

        }
        else if (NPCRegen >= 5.0f && Timecnt <= 60.0f)
        {
            NPCRegen -= 5.0f;
            for (int i = 0; i < PosNum; i++)
            {
                GameObject Temp = Instantiate(CNNPC, Position[i].transform.position, Quaternion.identity);
            }

        }
        else if (NPCRegen >= 5.0f && Timecnt <= 80.0f)
        {
            NPCRegen -= 5.0f;
            for (int i = 0; i < PosNum; i++)
            {
                GameObject Temp = Instantiate(CSNPC, Position[i].transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (NPCRegen >= 5.0f)
            {
                NPCRegen -= 5.0f; random++;
                for (int i = 0; i < PosNum / 4; i++)
                {
                    GameObject Temp1 = Instantiate(NNPC, Position[(i * 4 + random) % PosNum].transform.position,
                        Quaternion.identity);
                    GameObject Temp2 = Instantiate(FNPC, Position[(i * 4 + random + 1) % PosNum].transform.position,
                        Quaternion.identity);
                    GameObject Temp3 = Instantiate(CNNPC, Position[(i * 4 + random + 2) % PosNum].transform.position,
                        Quaternion.identity);
                    GameObject Temp4 = Instantiate(CSNPC, Position[(i * 4 + random + 3) % PosNum].transform.position,
                        Quaternion.identity);
                }
            }
        }
    }
}
