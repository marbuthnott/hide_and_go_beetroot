using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverheadCamera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        transform.position = new Vector3(50, 20, 0);
    }
}
