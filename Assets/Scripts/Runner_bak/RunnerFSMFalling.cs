using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RunnerFSMFalling : RunnerFSM
{
    public override void OnEnter(RunnerManager _manager)
    {
        base.OnEnter(_manager);
        Manager.animator.SetTrigger("Falling");
        Manager.isFalling = true;
    }

    public override void OnExit(RunnerManager _manager)
    {
        base.OnExit(_manager);
        Manager.animator.SetTrigger("Falling");
    }

    public float FallSpeed;

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector3 falling = -Vector3.up + Manager.Direction;
        transform.position += falling * FallSpeed * Time.deltaTime;
        Turn();
    }

    public void Turn()
    {
        Quaternion newRot = Quaternion.LookRotation(Manager.Direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, 15f * Time.deltaTime);
    }

}
