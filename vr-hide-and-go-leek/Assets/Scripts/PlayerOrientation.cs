using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public Canvas canvas;

    public void ShowOverheadView() {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        canvas.worldCamera = overheadCamera;
        UnityEngine.XR.InputTracking.Recenter();
    }
    
    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    void Start()
    {
        ShowFirstPersonView();
    }
}