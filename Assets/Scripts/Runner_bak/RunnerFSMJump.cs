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

       
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        bool isGround = Manager.GroundCheck();

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

        Manager.Run();
        Manager.Turn();
    }

}
