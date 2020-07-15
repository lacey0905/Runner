using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFSMRun : RunnerFSM
{
    public override void OnEnter(RunnerManager _manager)
    {
        base.OnEnter(_manager);
        Manager.animator.SetBool("Run", true);
    }

    public override void OnExit(RunnerManager _manager)
    {
        base.OnExit(_manager);
        Manager.animator.SetBool("Run", false);
        Manager.animator.SetLayerWeight(1, 0f);
    }

    public float speed;
    public float turnSpeed;
    [Range(0f, 0.5f)]
    public float groundRayRange;
    [Range(0f, 0.5f)]
    public float edgeRayRange;

    //private Vector3 direction = Vector3.forward;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (EdgeCheck(transform.position, -transform.up, edgeRayRange))
        {
            Manager.animator.SetLayerWeight(1, 0f);
        }
        else
        {
            Manager.animator.SetLayerWeight(1, 0.76f);
        }

        if (!GroundCheck(transform.position, -transform.up, groundRayRange))
        {
            Manager.SetState(State.Fall);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Manager.Direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Manager.Direction = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Manager.SetState(State.Jump);
        }

        Movement();
        Turn();

    }

    public void Turn()
    {
        Quaternion newRot = Quaternion.LookRotation(Manager.Direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
    }

    private void Movement()
    {
        transform.position += Manager.Direction * speed * Time.deltaTime;
    }

    private bool GroundCheck(Vector3 origin, Vector3 dir, float range)
    {
        bool p1 = Manager.DrawRayCast(origin - transform.right * range, dir);
        bool p2 = Manager.DrawRayCast(origin + transform.right * range, dir);
        return p1 || p2;
    }

    private bool EdgeCheck(Vector3 origin, Vector3 dir, float range)
    {
        bool p1 = Manager.DrawRayCast(origin - transform.right * range, dir);
        bool p2 = Manager.DrawRayCast(origin + transform.right * range, dir);
        return p1 && p2;
    }

}
