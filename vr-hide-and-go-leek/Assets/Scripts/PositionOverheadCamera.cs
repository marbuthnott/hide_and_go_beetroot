using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverheadCamera : MonoBehaviour
{
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputTracking.Recenter();
        transform.position = new Vector3(40, 55, 0);
    }

    void Update()
    {
        // Debug.Log(transform.position);
    }
}
