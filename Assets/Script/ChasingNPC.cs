using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingNPC : MonoBehaviour
{
    public float Speed;
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

        nav.speed = 13.0f;

        Player = GameObject.FindGameObjectWithTag("Player");

        Speed = 15.0f;
        rotateSpeed = 15.0f;
        ChasingDis = 45.0f;

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

        float nextThinkTime = Random.Range(3.0f, 5.0f);
        Invoke("Think", nextThinkTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" && !nav.enabled)
        {
            CancelInvoke();
            verticalMove *= -1; horizontalMove *= -1;
            Speed = Random.Range(10.0f, 20.0f);
            Invoke("Think", 3.0f);
        }
    }

    void Chase() 
    {
        nav.SetDestination(Player.transform.position);
    }

}
