using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter()
    {

        SceneManager.LoadScene("EndMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
