using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingNPCMove : MonoBehaviour
{
    public float Speed;
    public float rotateSpeed;

    Vector3 Movement;
    public float horizontalMove;
    public float verticalMove;

    Rigidbody rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Speed = 15.0f;
        rotateSpeed = 15.0f;

        Think();
    }

    void FixedUpdate()
    {
        Turn();
        Move();
    }

    //---------------------------------------- [ Action Function ]
    void Move()
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
        Speed = Random.Range(10.0f, 20.0f);
        anim.SetFloat("MoveSpeed", Speed);

        float nextThinkTime = Random.Range(3.0f, 5.0f);
        Invoke("Think", nextThinkTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CancelInvoke();
            horizontalMove *= -1;
            Speed = Random.Range(15.0f, 30.0f);
            Invoke("Think", 3.0f);
        }
    }
}
