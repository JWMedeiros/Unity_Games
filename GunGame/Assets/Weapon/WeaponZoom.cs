using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float fovInitial = 60f;
    [SerializeField] float zoomSens = 0.7f;
    [SerializeField] float nonZoomSens = 1f;
    FirstPersonController playerController;
    CinemachineVirtualCamera mainCamera;
    bool zoomedInToggle = false;

    private void Awake() 
    {
        mainCamera = FindObjectOfType<CinemachineVirtualCamera>();
        playerController = FindObjectOfType<FirstPersonController>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle==false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void OnDisable() 
    {
        ZoomOut();
    }

    void ZoomIn()
    {
        zoomedInToggle=true;
        playerController.RotationSpeed=zoomSens;
        mainCamera.m_Lens.FieldOfView=zoomedInFOV;
    }

    void ZoomOut()
    {
        zoomedInToggle=false;
        playerController.RotationSpeed=nonZoomSens;
        mainCamera.m_Lens.FieldOfView=fovInitial;
    }
}
