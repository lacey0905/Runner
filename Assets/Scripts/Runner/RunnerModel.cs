using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerModel : MonoBehaviour
{


    public float turnSpeed;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        anim.SetBool("Die", true);
    }

    public void Turn(Vector3 forward)
    {
        Quaternion newRot = Quaternion.LookRotation(forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * turnSpeed);
    }

    public void DirectTurn(Vector3 forward)
    {
        Quaternion newRot = Quaternion.LookRotation(forward);
        transform.rotation = newRot;
    }


}
