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

    public List<GameObject> models = new List<GameObject>();

    [HideInInspector] public Animator animator;

    bool isStart = false;
    [HideInInspector] public bool isFalling = false;

    public float moveSpeed;
    public float turnSpeed;

    GameObject currentModel = null;

    public void ChangeModel(int _model)
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
            models[_model].SetActive(true);
        }
        models[_model].SetActive(true);
        currentModel = models[_model];
        animator = models[_model].GetComponent<Animator>();
    }

    private Vector3 currentDirection = Vector3.forward;
    public Vector3 Direction
    {
        get { return currentDirection; }
        set { currentDirection = value; }
    }

    public Rigidbody rigidbody;

    private void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();

        ChangeModel(0);
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

    private void FixedUpdate()
    {
        stateDic[(int)currentState].OnFixedUpdate();
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

    public void Run()
    {
        //transform.position += Direction * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + Direction * moveSpeed * Time.deltaTime);
    }

    public void Turn()
    {
        Quaternion newRot = Quaternion.LookRotation(Direction);
        rigidbody.rotation = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
    }

    [Range(0f, 5f)]
    public float groundRayRange;
    [Range(0f, 0.5f)]
    public float edgeRayRange;

    public bool GroundCheck()
    {
        bool p1 = DrawRayCast(transform.position - Vector3.forward * groundRayRange, -Vector3.up);
        bool p2 = DrawRayCast(transform.position + Vector3.forward * groundRayRange, -Vector3.up);
        bool p3 = DrawRayCast(transform.position + Vector3.right * groundRayRange, -Vector3.up);
        bool p4 = DrawRayCast(transform.position - Vector3.right * groundRayRange, -Vector3.up);
        return p1 || p2 || p3 || p4;
    }

    public bool EdgeCheck()
    {
        Vector3 dir = Direction != Vector3.forward ? Vector3.forward : Vector3.right;
        bool p1 = DrawRayCast(transform.position - dir * edgeRayRange, -Vector3.up);
        bool p2 = DrawRayCast(transform.position + dir * edgeRayRange, -Vector3.up);
        return p1 && p2;
    }

}
