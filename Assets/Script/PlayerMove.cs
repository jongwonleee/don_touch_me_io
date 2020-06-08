using System.Collections;
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

    Rigidbody rigid;
    Animator anim;
    CapsuleCollider Ccollider;
    BoxCollider Bcollider;
    MeshRenderer render;
    void Awake()
    {
        //Initialize Component
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Ccollider = GetComponent<CapsuleCollider>();
        Bcollider = GetComponent<BoxCollider>();
        render = GetComponent<MeshRenderer>();

        Speed = 4.0f;
        Mask = false;
        rotateSpeed = 15.0f;
    }

    void Update()
    {
        if (gameObject.layer == 8)
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
        if (collision.gameObject.tag == "NPC") 
        {
            Damaged();
        }
        if (collision.gameObject.tag == "Haste") 
        {
            Faster();   Invoke("Slower", 5);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Mask") 
        {
            Mask = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Shield") 
        {
            Invincibility();
            Invoke("DeActive", 5.0f);
        }
    }

    void Damaged()
    {
        if (Mask == false)
        {
            gameObject.layer = 9;
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Ccollider.enabled = false;
            Bcollider.enabled = true;
            anim.SetBool("isHit", true);
        }
        else 
        {
            Mask = false;
            Invincibility();
            Invoke("DeActive", 2.0f);
        }
    }

    void Faster() 
    {
        Speed = 6.0f;
        anim.SetBool("isBoost", true);
    }

    void Slower() 
    {
        Speed = 4.0f;
        anim.SetBool("isBoost", false);
    }

    void Invincibility() 
    {
        gameObject.layer = 9;
    }

    void DeActive() 
    {
        gameObject.layer = 8;
    }
}
