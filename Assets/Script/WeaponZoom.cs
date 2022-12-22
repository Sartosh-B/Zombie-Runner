using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomInFOV = 30.0f;
    [SerializeField] float zoomOutFOV = 60.0f;

    [SerializeField] float zoomOutSensitivity = 2.0f;
    [SerializeField] float zoomInSensitivity = 1.0f;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        ZoomController();
    }

    private void ZoomController()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    public void ZoomOut()
    {        
         zoomedInToggle = false;
         fpsCamera.fieldOfView = zoomOutFOV;
         fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
         fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
                  
    }

}
