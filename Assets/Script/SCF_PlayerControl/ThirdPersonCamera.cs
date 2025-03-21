using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    private PlayerController playerController;

    [Header("Customization")]
    [SerializeField] private float roatationSpeed;
    [SerializeField] private CameraStyle currentStyle;
    [SerializeField] Transform dropDownLookAt;

    
    public enum CameraStyle
    {
        Basic,
        FirstPerSon,
    } 
    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    // Update is called once per frame
    void Update()
    {
        if(playerController.isDead)
        {
            return;
        }


        if(currentStyle == CameraStyle.Basic)
        {
            Vector3 viewDir = player.position - new Vector3(transform.position.x , player.position.y , transform.position.z);
            orientation.forward = viewDir.normalized;

            float horizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * VerticalInput + orientation.right * horizontalInput;

            if(inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward , inputDir.normalized, Time.deltaTime * roatationSpeed);
            }
        }
    }


        
    
}
