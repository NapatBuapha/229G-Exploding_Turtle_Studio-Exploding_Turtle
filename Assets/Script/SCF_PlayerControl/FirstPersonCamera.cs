using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float sensX , sensY;

    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject[] playerParts;
    private MeshRenderer meshRenderer;
    

    private float xRotation,yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        foreach (GameObject part in playerParts)
        {
            meshRenderer = part.GetComponent<MeshRenderer>();
            meshRenderer.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
    }

    private void OnDisable()
    {
        if(playerParts != null)
        {
        foreach (GameObject part in playerParts)
        {
            meshRenderer = part.GetComponent<MeshRenderer>();
            meshRenderer.shadowCastingMode = ShadowCastingMode.On;
        }
        }
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f,90f);

        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        orientation.rotation = Quaternion.Euler(0,yRotation,0);
        playerObj.transform.rotation = Quaternion.Euler(0,yRotation,0);

    }
}
