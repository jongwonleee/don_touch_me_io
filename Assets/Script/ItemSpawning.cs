using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    public int PosNum;
    public int Posrandom;
    public int Itemrandom;

    public GameObject Shield;
    public GameObject Mask;
    public GameObject Haste;
    public GameObject Smaller;

    public GameObject[] Pos;
    public bool[] flag;

    PlayerMove PM;

    void Awake()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        for (int i = 0; i < 13; i++)
        {
            flag[i] = true;
        }
    }

    void Update()
    {
        if (PM.isItem)
        {
            PM.isItem = false;
            Invoke("CreateItem", 5);
        }
    }

    public void CreateItem()
    {
        Posrandom = Random.Range(0, PosNum);
        Itemrandom = Random.Range(0, 4);
        for (int i = 0; i < 13; i++)
        {
            int index = (i + Posrandom) % 13;
            if (flag[index])
            {
                Posrandom = index;
                break;
            }
        }
        flag[Posrandom] = false;
        switch (Itemrandom % 4)
        {
            case 0:
                CreateShield(Pos[Posrandom]);
                break;
            case 1:
                CreateMask(Pos[Posrandom]);
                break;
            case 2:
                CreateHaste(Pos[Posrandom]);
                break;
            case 3:
                CreateSmaller(Pos[Posrandom]);
                break;
            default:
                break;
        }
    }

    void CreateShield(GameObject pos)
    {
        GameObject Temp = Instantiate(Shield, pos.transform.position, Quaternion.identity);
    }

    void CreateMask(GameObject pos)
    {
        GameObject Temp = Instantiate(Mask, pos.transform.position, Quaternion.identity);
    }

    void CreateHaste(GameObject pos)
    {
        GameObject Temp = Instantiate(Haste, pos.transform.position, Quaternion.identity);
    }

    void CreateSmaller(GameObject pos)
    {
        GameObject Temp = Instantiate(Smaller, pos.transform.position, Quaternion.identity);
    }
}
