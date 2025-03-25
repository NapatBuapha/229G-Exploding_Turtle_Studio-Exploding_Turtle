using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    [SerializeField] GameObject tpCam,fpCam; 
    public enum CameraStyle
    {
        FirstPerson,
        ThirdPerson,
    }

    [SerializeField] private CameraStyle currentCamera;

    void Start()
    {
        currentCamera = CameraStyle.ThirdPerson;
        fpCam.SetActive(false);
        tpCam.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwapCamera();
        }
    }

    void SwapCamera()
    {
        switch(currentCamera)
        {
            case CameraStyle.FirstPerson:
            tpCam.SetActive(true);
            fpCam.SetActive(false);
            currentCamera = CameraStyle.ThirdPerson;
            break;

            case CameraStyle.ThirdPerson:
            fpCam.SetActive(true);
            tpCam.SetActive(false);
            currentCamera = CameraStyle.FirstPerson;
            break;
        }
    }
}
