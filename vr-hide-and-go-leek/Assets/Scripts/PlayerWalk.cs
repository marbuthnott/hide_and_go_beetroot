using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    public int playerSpeed;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
    }
}
