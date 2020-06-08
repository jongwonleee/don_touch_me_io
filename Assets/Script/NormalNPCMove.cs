﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNPCMove : MonoBehaviour
{
    public float Speed;
    public float rotateSpeed = 15.0f;

    Vector3 Movement;
    public float verticalMove;
    public float horizontalMove;

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Invoke("Think", 0.5f);
    }

    void FixedUpdate()
    {
        Turn();
        Walk();
    }

    //-------------------------------- [ Action Function ]
    void Walk() 
    {
        Movement.Set(horizontalMove, 0, verticalMove);
        Movement = Movement.normalized * Speed * Time.deltaTime;

        rigid.MovePosition(transform.position + Movement);
    }

    void Turn()
    {
        Quaternion newRotation = Quaternion.LookRotation(Movement);

        rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void Think() 
    {
        verticalMove = Random.Range(-5.0f, 5.0f);
        horizontalMove = Random.Range(-5.0f, 5.0f);

        float nextThinkTime = Random.Range(2.0f, 3.0f);

        Invoke("Think", nextThinkTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") {
            CancelInvoke();
            verticalMove *= -1; horizontalMove *= -1;
            Invoke("Think", 3.0f);
        }
    }
}