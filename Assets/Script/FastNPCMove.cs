using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastNPCMove : MonoBehaviour
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

        Speed = 20.0f;
        rotateSpeed = 15.0f;

        Invoke("Think", 0.5f);
    }

    void FixedUpdate()
    {
        Turn();
        Run();
    }

    //------------------------------------- [ Action Function ]
    void Run() 
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
        if (collision.gameObject.tag == "Wall")
        {
            CancelInvoke();
            verticalMove *= -1; horizontalMove *= -1;
            Invoke("Think", 3.0f);
        }
    }
}
