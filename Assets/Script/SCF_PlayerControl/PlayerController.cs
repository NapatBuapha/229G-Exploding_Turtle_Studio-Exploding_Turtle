using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    private Rigidbody rb;
    private RaycastHit hit;
    private Ray groundCheckingRay;

    //Variable
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isTouchGround;
    [SerializeField] private float checkingDistance = 1f;

    //Object refference
    [SerializeField] private Transform groundCheckRef;
 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        isTouchGround = true;
    }

   
    void Update()
    {
        //Jump System Start

        if(Input.GetKey(KeyCode.Space) && isTouchGround == true)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        groundCheckingRay = new Ray(groundCheckRef.position,-transform.up);
        
        if(Physics.Raycast(groundCheckingRay , out hit, checkingDistance))
        {
   
            isTouchGround = true;

        }
        else
        {
            isTouchGround = false;
        }

        //Jump System end



    }

    
    


}
