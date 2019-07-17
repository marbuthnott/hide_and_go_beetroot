using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraInteraction : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButton(0)) {
        	Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	RaycastHit rayhit;
        	if (Physics.Raycast(mouseray, out rayhit, 1000.0f)) {
        		if (rayhit.transform.name == "GoSphere") {
        			GameObject.Find("GoSphere").SetActive(false);

        			GameObject.Find("EasySphere").GetComponent<MeshRenderer>().enabled = true;
        			GameObject.Find("EasyTextSphere").GetComponent<MeshRenderer>().enabled = true;

        			GameObject.Find("MediumSphere").GetComponent<MeshRenderer>().enabled = true;
        			GameObject.Find("MediumTextSphere").GetComponent<MeshRenderer>().enabled = true;

        			GameObject.Find("HardSphere").GetComponent<MeshRenderer>().enabled = true;
        			GameObject.Find("HardTextSphere").GetComponent<MeshRenderer>().enabled = true;
        		}

        		if (rayhit.transform.name == "EasySphere") {
        			SceneManager.LoadScene("Main");
        		}

        		if (rayhit.transform.name == "MediumSphere") {
        			SceneManager.LoadScene("Main");
        		}

        		if (rayhit.transform.name == "HardSphere") {
        			SceneManager.LoadScene("Main");
        		}
        	}
        }
    }
}
