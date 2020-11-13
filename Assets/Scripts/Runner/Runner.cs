using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    Rigidbody rigidbody;

    public float speed;
    public float dropSpeed;

    public RunnerModel model;

    public enum Direction { Left, Right }
    public Direction currentDir;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentDir = Direction.Left;
    }

    private void Update()
    {

        if (isDie) return;

        if (currentDir == Direction.Left)
        {
            model.Turn(Vector3.forward);
        }
        else if (currentDir == Direction.Right)
        {
            model.Turn(Vector3.right);
        }

        if (Input.GetMouseButtonDown(0))
        {
            currentDir = currentDir == Direction.Left ? Direction.Right : Direction.Left;
        }

    }

    private void FixedUpdate()
    {
        if (isDie) return;
        Movement();
        GroundCheck();
    }

    private void Movement()
    {
        Vector3 dir = GetCurrentDirection();
        Vector3 newPos = dir * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + newPos);
    }

    public float margin;

    bool isDie = false;

    private Vector3 GetCurrentDirection()
    {
        return currentDir == Direction.Left ? Vector3.forward : Vector3.right;
    }

    private void GroundCheck()
    {

        float dist = 1f;
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        Vector3 fOrigin = origin + (currentDir == Direction.Left ? Vector3.forward : Vector3.right) * margin;
        Vector3 lOrigin = origin - (currentDir == Direction.Left ? Vector3.right : Vector3.forward) * margin;
        Vector3 rOrigin = origin + (currentDir == Direction.Left ? Vector3.right : Vector3.forward) * margin;
        RaycastHit front, left, right;

        bool fHit = Physics.Raycast(fOrigin, -Vector3.up, out front, dist);
        bool lHit = Physics.Raycast(lOrigin, -Vector3.up, out left, dist);
        bool rHit = Physics.Raycast(rOrigin, -Vector3.up, out right, dist);

        DrawGroundRay(fOrigin, fHit ? Color.green : Color.red);
        DrawGroundRay(lOrigin, lHit ? Color.green : Color.red);
        DrawGroundRay(rOrigin, rHit ? Color.green : Color.red);

        if (!fHit && !lHit && !rHit)
        {
            // 패배
            // 패배하면 패배 플로우

            model.Die();
            isDie = true;

            model.DirectTurn(GetCurrentDirection());

            rigidbody.useGravity = true;
            rigidbody.AddForce(GetCurrentDirection() * dropSpeed, ForceMode.Impulse);
            rigidbody.AddTorque(new Vector3(Random.Range(0f, 1f), Random.Range(-1f, 1f), Random.Range(0f, 1f)) * 35f);
        }
        else if (lHit || rHit || fHit)
        {
            // 반 걸침
            // 애니메이션 블랜드
        }
        else if (lHit && rHit && fHit)
        {
            // 정상
            // 애니메이션 블랜드 제거
        }
    }

    private void DrawGroundRay(Vector3 origin, Color color)
    {
        Debug.DrawRay(origin, -Vector3.up, color);
    }


}
