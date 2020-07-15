using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFSMIdle : RunnerFSM
{
    public override void OnEnter(RunnerManager _manager)
    {
        base.OnEnter(_manager);
        Manager.animator.SetBool("Idle", true);
    }

    public override void OnExit(RunnerManager _manager)
    {
        base.OnExit(_manager);
        Manager.animator.SetBool("Idle", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Manager.SetState(State.Run);
        }


    }
}
