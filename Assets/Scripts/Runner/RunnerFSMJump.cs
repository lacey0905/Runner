using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RunnerFSMJump : RunnerFSM
{
    public override void OnEnter(RunnerManager _manager)
    {
        base.OnEnter(_manager);
        Manager.animator.SetBool("Jump", true);
        curTime = 0f;
    }

    public override void OnExit(RunnerManager _manager)
    {
        base.OnExit(_manager);
        Manager.animator.SetBool("Jump", false);
    }

    public float speed;
    public float turnSpeed;

    public float timer;
    private float curTime;

    public override void OnUpdate()
    {
        base.OnUpdate();
        Movement();
        Turn();

        bool isGround = GroundCheck(transform.position, -transform.up, 0.3f);

        if (curTime > timer)
        {
            if (isGround)
            {
                Manager.SetState(State.Run);
            }
            else
            {
                Manager.SetState(State.Fall);
            }
        }
        else
        {
            curTime += Time.deltaTime;
        }
        
    }

    private void Movement()
    {
        transform.position += Manager.Direction * speed * Time.deltaTime;
    }

    public void Turn()
    {
        Quaternion newRot = Quaternion.LookRotation(Manager.Direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
    }

    private bool GroundCheck(Vector3 origin, Vector3 dir, float range)
    {
        bool p1 = Manager.DrawRayCast(origin - transform.right * range, dir);
        bool p2 = Manager.DrawRayCast(origin + transform.right * range, dir);
        return p1 || p2;
    }

}
