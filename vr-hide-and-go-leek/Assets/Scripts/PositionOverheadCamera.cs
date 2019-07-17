using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOverheadCamera : MonoBehaviour
{
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(40, 20, 25);
    }

    void Update()
    {
        // Debug.Log(transform.position);
    }
}
