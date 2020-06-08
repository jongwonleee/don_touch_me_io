using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;

    public float Xoffset = 0f;
    public float Yoffset = 50f;
    public float Zoffset = -60f;

    public float followSpeed;

    Vector3 CameraPosition;
    void LateUpdate()
    {
        CameraPosition.x = Player.transform.position.x + Xoffset;
        CameraPosition.y = Player.transform.position.y + Yoffset;
        CameraPosition.z = Player.transform.position.z + Zoffset;

        transform.position = Vector3.Lerp(transform.position, CameraPosition, followSpeed * Time.deltaTime);
    }
}
