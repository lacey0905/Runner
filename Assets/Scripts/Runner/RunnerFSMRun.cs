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
  

    //private Vector3 direction = Vector3.forward;

    public override void OnUpdate()
    {
        base.OnUpdate();
        

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

    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (!Manager.GroundCheck())
        {
            Manager.SetState(State.Fall);
        }
        if (Manager.EdgeCheck())
        {
            Manager.animator.SetLayerWeight(1, 0f);
        }
        else
        {
            Manager.animator.SetLayerWeight(1, 0.76f);
        }
        Manager.Run();
        Manager.Turn();
        
    }

}
