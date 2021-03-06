﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public float rotateSpeed;
   
    Vector3 Movement;
    float verticalmove;
    float horizontalmove;

    bool Mask;
    public bool isItem;

    public Canvas canvasMain;
    public Canvas canvasEnd;
    public AudioSource dead;

    Rigidbody rigid;
    Animator anim;
    CapsuleCollider Ccollider;
    BoxCollider Bcollider;
    void Awake()
    {
        //Initialize Component
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Ccollider = GetComponent<CapsuleCollider>();
        Bcollider = GetComponent<BoxCollider>();

        Mask = false;
        isItem = false;

        Speed = 30.0f;
        rotateSpeed = 15.0f;
    }

    void Update()
    {
        if (gameObject.layer != 9 && canvasMain.enabled)
        {
            verticalmove = Input.GetAxisRaw("Vertical");
            horizontalmove = Input.GetAxisRaw("Horizontal");
        }
        AnimationUpdate();
    }

    void FixedUpdate()
    {
        Turn();
        Walk();
    }

    void AnimationUpdate() 
    {
        if (horizontalmove == 0 && verticalmove == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    //--------------------------- [ Action Function ]
    void Walk() 
    {
        Movement.Set(horizontalmove, 0, verticalmove);
        Movement = Movement.normalized * Speed * Time.deltaTime;

        rigid.MovePosition(transform.position + Movement);
    }

    void Turn()
    {
        if (horizontalmove == 0 && verticalmove == 0)
            return;
        Quaternion newRotation = Quaternion.LookRotation(Movement);

        rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC" && gameObject.layer == 8) 
        {
            Damaged();
        }
        if (collision.gameObject.tag == "Haste") 
        {
            CancelInvoke("Slower");
            Faster();   Invoke("Slower", 10);
            collision.gameObject.SetActive(false);
            isItem = true;
        }
        if (collision.gameObject.tag == "Mask") 
        {
            Mask = true;
            collision.gameObject.SetActive(false);
            ItemUIShow.itemMaskShow = true;
            isItem = true;

        }
        if (collision.gameObject.tag == "Shield")
        {
            CancelInvoke("DeActive");
            collision.gameObject.SetActive(false);
            Invincibility();
            Invoke("DeActive", 10.0f);
            ItemUIShow.itemShieldShow = true;
            isItem = true;
        }
        if (collision.gameObject.tag == "Smaller") 
        {
            CancelInvoke("Bigger");
            collision.gameObject.SetActive(false);
            Smaller();
            Invoke("Bigger", 10.0f);
            isItem = true;
        }
    }

    void Damaged()
    {
        if (Mask == false)
        {
            canvasMain.enabled = false;
            canvasEnd.enabled = true;
            gameObject.layer = 9;
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Ccollider.enabled = false;
            Bcollider.enabled = true;
            verticalmove = 0;
            horizontalmove = 0;
            anim.SetBool("isHit", true);
            dead.Play();
        }
        else 
        {
            Mask = false;
            Invincibility();
            ItemUIShow.itemMaskShow = false;
            Invoke("DeActive", 2.0f);
        }
    }

    void Faster() 
    {
        Speed = 60.0f;
        anim.SetBool("isBoost", true);
        ItemUIShow.itemHeistShow = true;
    }

    void Slower() 
    {
        Speed = 30.0f;
        anim.SetBool("isBoost", false);
        ItemUIShow.itemHeistShow = false;
    }

    void Invincibility() 
    {
        gameObject.layer = 10;
    }

    void DeActive() 
    {
        gameObject.layer = 8;
        ItemUIShow.itemShieldShow = false;

    }

    void Smaller() {
        gameObject.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        ItemUIShow.itemSizeShow = true;
    }

    void Bigger() {
        gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        ItemUIShow.itemSizeShow = false;
    }
}
