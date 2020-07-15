using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    bool isLeft = true;

    Quaternion newRot;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        newRot = Quaternion.LookRotation(transform.forward);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (isLeft)
            {
                newRot = Quaternion.LookRotation(Vector3.right);
                isLeft = false;
            }
            else
            {
                newRot = Quaternion.LookRotation(Vector3.forward);
                isLeft = true;
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Jump 0");
        }

        transform.position += transform.forward * speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);

    }

}
