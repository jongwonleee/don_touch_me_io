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

    public Canvas canvasMain;
    public Canvas canvasEnd;

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

        Speed = 15.0f;
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
            collision.gameObject.SetActive(false);
            Invincibility();
            Invoke("DeActive", 5.0f);
        }
        if (collision.gameObject.tag == "Smaller") 
        {
            collision.gameObject.SetActive(false);
            Smaller();
            Invoke("Bigger", 5.0f);
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
        Speed = 30.0f;
        anim.SetBool("isBoost", true);
    }

    void Slower() 
    {
        Speed = 15.0f;
        anim.SetBool("isBoost", false);
    }

    void Invincibility() 
    {
        gameObject.layer = 10;
    }

    void DeActive() 
    {
        gameObject.layer = 8;
    }

    void Smaller() {
        gameObject.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    void Bigger() {
        gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
    }
}
