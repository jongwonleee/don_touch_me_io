using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIShow : MonoBehaviour
{
    public static bool itemMaskShow;
    public static bool itemShieldShow;
    public static bool itemHeistShow;
    public static bool itemSizeShow;
    public GameObject itemMask;
    public GameObject itemShield;
    public GameObject itemHeist;
    public GameObject itemSize;

    // Start is called before the first frame update
    void Start()
    {
        itemHeistShow = false;
        itemMaskShow = false;
        itemShieldShow = false;
        itemSizeShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemHeistShow) itemHeist.SetActive(true);
        else itemHeist.SetActive(false);
        if (itemMaskShow) itemMask.SetActive(true);
        else itemMask.SetActive(false);
        if (itemShieldShow) itemShield.SetActive(true);
        else itemShield.SetActive(false);
        if (itemSizeShow) itemSize.SetActive(true);
        else itemSize.SetActive(false);
    }
}
