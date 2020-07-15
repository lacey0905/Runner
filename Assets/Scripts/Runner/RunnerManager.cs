using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle = 0,
    Run,
    Jump,
    Fall
}

public class RunnerManager : MonoBehaviour
{
    [SerializeField]
    State currentState;

    public List<RunnerFSM> stateList = new List<RunnerFSM>();
    Dictionary<int, RunnerFSM> stateDic = new Dictionary<int, RunnerFSM>();

    RunnerAnimation anim;
    public Animator animator { get { return anim.GetAnimator(); } }

    bool isStart = false;


    public bool isFalling = false;


    private Vector3 currentDirection;
    public Vector3 Direction
    {
        get
        {
            return currentDirection;
        }
        set
        {
            currentDirection = value;
        }
    }

    private void Awake()
    {
        anim = GetComponent<RunnerAnimation>();
        anim.ChangeModel(0);
        Direction = Vector3.forward;

        for (int i = 0; i < stateList.Count; i++)
        {
            stateDic.Add(i, stateList[i]);
        }
        SetState(State.Idle);
    }

    private void Update()
    {
        stateDic[(int)currentState].OnUpdate();
    }

    public void SetState(State newState)
    {
        if(isStart)
        {
            stateDic[(int)currentState].OnExit(this);
        }
        else
        {
            isStart = true;
        }
        stateDic[(int)newState].OnEnter(this);
        currentState = newState;
    }

    public bool DrawRayCast(Vector3 origin, Vector3 dir)
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(origin, dir, out hit);
        if (isHit)
        {
            Debug.DrawRay(origin, dir * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(origin, dir * 1000f, Color.yellow);
        }
        return isHit;
    }

}
