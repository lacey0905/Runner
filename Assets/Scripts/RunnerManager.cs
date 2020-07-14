using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{

    public float range;

    bool leftCheck = false;
    bool rightCheck = false;

    private void FixedUpdate()
    {

        RaycastHit hit;

        Vector3 leftRay = transform.position - transform.right * range;
        Vector3 rightRay = transform.position + transform.right * range;

        if (Physics.Raycast(leftRay, -transform.up, out hit))
        {
            Debug.DrawRay(leftRay, -transform.up * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(leftRay, -transform.up * 1000f, Color.red);
        }

        if (Physics.Raycast(rightRay, -transform.up, out hit))
        {
            Debug.DrawRay(rightRay, -transform.up * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rightRay, -transform.up * 1000f, Color.red);
        }

        leftCheck = Physics.Raycast(leftRay, -transform.up, out hit);
        rightCheck = Physics.Raycast(rightRay, -transform.up, out hit);

        if(!leftCheck && !rightCheck)
        {
            Debug.Log("번지");
        }
        else if (!leftCheck || !rightCheck)
        {
            Debug.Log("아슬");
        }

    }

}
