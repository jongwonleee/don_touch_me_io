using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    public AudioSource gotItem;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm.playOnAwake = true;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Haste")
        {
            gotItem.Play();
        }
        if (collision.gameObject.tag == "Mask")
        {
            gotItem.Play();

        }
        if (collision.gameObject.tag == "Shield")
        {
            gotItem.Play();

        }
        if (collision.gameObject.tag == "Smaller")
        {
            gotItem.Play();

        }
    }
}
