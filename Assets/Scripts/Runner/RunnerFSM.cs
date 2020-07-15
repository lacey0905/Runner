using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerFSM : MonoBehaviour
{
    RunnerManager manager;
    public RunnerManager Manager
    {
        get { return manager; }
    }

    public virtual void OnEnter(RunnerManager _manager)
    {
        this.manager = _manager;
    }
    public virtual void OnExit(RunnerManager _manager)
    {
        this.manager = _manager;
    }
    public virtual void OnUpdate() { }
}
