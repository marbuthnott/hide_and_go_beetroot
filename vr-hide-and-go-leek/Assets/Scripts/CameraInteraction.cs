using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraInteraction : MonoBehaviour {

	public string internalObject;
	public RaycastHit theObject;
	private LoadOnClick difficultyPicker;

	void Start()
	{
		difficultyPicker = GameObject.Find("DifficultyPicker").GetComponent(typeof(LoadOnClick)) as LoadOnClick;
	}

	// Update is called once per frame
	void Update() {
			if(Input.GetMouseButtonUp(0)) {
				if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject)) {
					if (theObject.transform.name == "GoSphere") {
						GameObject.Find("GoSphere").SetActive(false);

						GameObject.Find("EasySphere").GetComponent<MeshRenderer>().enabled = true;
						GameObject.Find("EasyTextSphere").GetComponent<MeshRenderer>().enabled = true;

						GameObject.Find("MediumSphere").GetComponent<MeshRenderer>().enabled = true;
						GameObject.Find("MediumTextSphere").GetComponent<MeshRenderer>().enabled = true;

						GameObject.Find("HardSphere").GetComponent<MeshRenderer>().enabled = true;
						GameObject.Find("HardTextSphere").GetComponent<MeshRenderer>().enabled = true;
					}

					if (theObject.transform.name == "EasySphere") {
						SceneManager.LoadScene("Main");
					}

					if (theObject.transform.name == "MediumSphere") {
						SceneManager.LoadScene("Main");
					}

					if (theObject.transform.name == "HardSphere") {
						SceneManager.LoadScene("Main");
					}

					if (theObject.transform.name == "StartMenuObject") {
						SceneManager.LoadScene("StartMenu");
					}
				}
			}
	}
}
