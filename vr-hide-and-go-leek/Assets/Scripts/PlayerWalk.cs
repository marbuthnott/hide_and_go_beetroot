using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    
    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0))
        // {
        //     Debug.Log("Pressed Fire1");
        // }

        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Pressed Fire1");
        }
    }
}
