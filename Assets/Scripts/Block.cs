using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public Transform front;

    public Vector3 GetFrontPos()
    {
        return front.transform.position;
    }

}
