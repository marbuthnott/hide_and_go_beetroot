using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputTracking.Recenter();
    }

}
