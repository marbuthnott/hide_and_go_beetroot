using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{


    public float maxPlayerSpeed;
    private float playerSpeed;

    void Start()
    {
        playerSpeed = 0.0F;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            if(playerSpeed < maxPlayerSpeed)
            {
                playerSpeed += 0.2F;
            }
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
        else if(playerSpeed > 0)
        {
            playerSpeed -= 0.4F;
        }
    }
}
