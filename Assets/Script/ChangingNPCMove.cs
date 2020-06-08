using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingNPCMove : MonoBehaviour
{
    public float Speed = 5.0f;
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

        Invoke("Think", 0.5f);
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
        Speed = Random.Range(3.0f, 6.0f);
        anim.SetFloat("MoveSpeed", Speed);

        float nextThinkTime = Random.Range(2.0f, 3.0f);
        Invoke("Think", nextThinkTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CancelInvoke();
            verticalMove *= -1; horizontalMove *= -1;
            Invoke("Think", 3.0f);
        }
    }
}
