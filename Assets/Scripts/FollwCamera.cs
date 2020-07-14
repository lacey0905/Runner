using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwCamera : MonoBehaviour
{

    public Transform target;
    public float speed;

    public float turn;

    public Transform arm;

    bool isArm = true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            isArm = !isArm;
        }

        if(isArm)
        {
            arm.rotation = Quaternion.Slerp(arm.rotation, Quaternion.Euler(new Vector3(40f, 30f, 0f)), turn * Time.deltaTime);
        }
        else
        {
            arm.rotation = Quaternion.Slerp(arm.rotation, Quaternion.Euler(new Vector3(40f, 60f, 0f)), turn * Time.deltaTime);
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
