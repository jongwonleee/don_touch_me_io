using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingNPC : MonoBehaviour
{
    public float Speed = 3.0f;
    public float rotateSpeed;

    Vector3 Offset;
    public float ChasingDis;

    Vector3 Movement;
    public float horizontalMove;
    public float verticalMove;

    Rigidbody rigid;
    Animator anim;
    NavMeshAgent nav;

    GameObject Player;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");

        Invoke("Think", 0.5f);
    }

    void Update()
    {
        Offset = transform.position - Player.transform.position;
        float Dis = Offset.sqrMagnitude;
        
        if (Dis < ChasingDis * ChasingDis && Player.layer == 8)
        {
            nav.enabled = true;
            anim.SetBool("isChasing", true);
            Chase();
        }
        else
        {
            nav.enabled = false;
            anim.SetBool("isChasing", false);
            Walk();
            Turn();
        }
    }

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
        horizontalMove = Random.Range(-5.0f, 5.0f);
        verticalMove = Random.Range(-5.0f, 5.0f);

        float nextThinkTime = Random.Range(2.0f, 3.0f);
        Invoke("Think", nextThinkTime);
    }

    void Chase() 
    {
        nav.SetDestination(Player.transform.position);
    }
}
