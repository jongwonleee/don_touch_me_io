using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Stop Character
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector3(rigid.velocity.normalized.x * 0.5f, 
                rigid.velocity.y, rigid.velocity.z);
        if (Input.GetButtonUp("Vertical"))
            rigid.velocity = new Vector3(rigid.velocity.x, 
                rigid.velocity.y, rigid.velocity.normalized.z * 0.5f);
    }

    void FixedUpdate()
    {
        //Move by Key Control
        float x = Input.GetAxisRaw("Vertical");
        rigid.AddForce(Vector3.forward * x, ForceMode.Impulse);
        float y = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector3.right * y, ForceMode.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector3(maxSpeed, rigid.velocity.y, rigid.velocity.z);
        if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector3(-maxSpeed, rigid.velocity.y, rigid.velocity.z);
        if (rigid.velocity.z > maxSpeed)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxSpeed);
        if (rigid.velocity.z < -maxSpeed)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -maxSpeed);
    }
}
