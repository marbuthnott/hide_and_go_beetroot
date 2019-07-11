using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{   
    public Camera camera;
        void Start()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);


        if(Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            Debug.Log("whatever");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
