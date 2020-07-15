using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    void FixedUpdate()
    {
        bool isFalling = target.GetComponent<RunnerManager>().isFalling;
        if(!isFalling)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
