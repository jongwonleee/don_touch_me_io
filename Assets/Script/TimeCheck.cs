using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCheck : MonoBehaviour
{
    float Timecnt;
    float NPCRegen;
    string Timestr;

    public Canvas canvasMain;

    public Text CurrentRecord;
    public Text CurrentScore;

    public GameObject NNPC;
    public GameObject FNPC;
    public GameObject CNNPC;
    public GameObject CSNPC;

    public GameObject Position1;
    public GameObject Position2;
    public GameObject Position3;
    public GameObject Position4;
    public GameObject Position5;
    public GameObject Position6;
    public GameObject Position7;

    void Awake()
    {
        Timecnt = 0.0f;
        NPCRegen = 0.0f;
        Timestr = "";
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

    void FlowOfTime() {
        Timecnt += Time.deltaTime;
        NPCRegen += Time.deltaTime;
        Timestr = Timecnt.ToString("N2");
        Timestr.Replace(".", ":");
    }

    void ShowTime(Text t) {
        t.text = Timestr;
    }

    void CreateNPC() {
        if (NPCRegen >= 5.0f && Timecnt <= 20.0f)
        {
            NPCRegen -= 5.0f;
            GameObject Temp1 = Instantiate(NNPC, Position1.transform.position, Quaternion.identity);
            GameObject Temp2 = Instantiate(NNPC, Position2.transform.position, Quaternion.identity);
            GameObject Temp3 = Instantiate(NNPC, Position3.transform.position, Quaternion.identity);
            GameObject Temp4 = Instantiate(NNPC, Position4.transform.position, Quaternion.identity);
            GameObject Temp5 = Instantiate(NNPC, Position5.transform.position, Quaternion.identity);
            GameObject Temp6 = Instantiate(NNPC, Position6.transform.position, Quaternion.identity);
            GameObject Temp7 = Instantiate(NNPC, Position7.transform.position, Quaternion.identity);
        }
        else if (NPCRegen >= 5.0f && Timecnt <= 40.0f)
        {
            NPCRegen -= 5.0f;
            GameObject Temp1 = Instantiate(FNPC, Position1.transform.position, Quaternion.identity);
            GameObject Temp2 = Instantiate(FNPC, Position2.transform.position, Quaternion.identity);
            GameObject Temp3 = Instantiate(FNPC, Position3.transform.position, Quaternion.identity);
            GameObject Temp4 = Instantiate(FNPC, Position4.transform.position, Quaternion.identity);
            GameObject Temp5 = Instantiate(FNPC, Position5.transform.position, Quaternion.identity);
            GameObject Temp6 = Instantiate(FNPC, Position6.transform.position, Quaternion.identity);
            GameObject Temp7 = Instantiate(FNPC, Position7.transform.position, Quaternion.identity);
        }
        else if (NPCRegen >= 5.0f && Timecnt <= 60.0f)
        {
            NPCRegen -= 5.0f;
            GameObject Temp1 = Instantiate(CNNPC, Position1.transform.position, Quaternion.identity);
            GameObject Temp2 = Instantiate(CNNPC, Position2.transform.position, Quaternion.identity);
            GameObject Temp3 = Instantiate(CNNPC, Position3.transform.position, Quaternion.identity);
            GameObject Temp4 = Instantiate(CNNPC, Position4.transform.position, Quaternion.identity);
            GameObject Temp5 = Instantiate(CNNPC, Position5.transform.position, Quaternion.identity);
            GameObject Temp6 = Instantiate(CNNPC, Position6.transform.position, Quaternion.identity);
            GameObject Temp7 = Instantiate(CNNPC, Position7.transform.position, Quaternion.identity);
        }
        else if (NPCRegen >= 5.0f && Timecnt <= 80.0f)
        {
            NPCRegen -= 5.0f;
            GameObject Temp1 = Instantiate(CSNPC, Position1.transform.position, Quaternion.identity);
            GameObject Temp2 = Instantiate(CSNPC, Position2.transform.position, Quaternion.identity);
            GameObject Temp3 = Instantiate(CSNPC, Position3.transform.position, Quaternion.identity);
            GameObject Temp4 = Instantiate(CSNPC, Position4.transform.position, Quaternion.identity);
            GameObject Temp5 = Instantiate(CSNPC, Position5.transform.position, Quaternion.identity);
            GameObject Temp6 = Instantiate(CSNPC, Position6.transform.position, Quaternion.identity);
            GameObject Temp7 = Instantiate(CSNPC, Position7.transform.position, Quaternion.identity);
        }
        else { 
        
        }
    }
}
