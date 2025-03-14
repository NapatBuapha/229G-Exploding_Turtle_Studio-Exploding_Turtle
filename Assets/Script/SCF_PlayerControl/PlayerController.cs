using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{


    //Components
    private Rigidbody rb;
    private RaycastHit hit;
    private Ray groundCheckingRay;

    //Variable [Jump]
    [Header("[Jump] setting")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isTouchGround;
    [SerializeField] private float checkingDistance = 1f;
    [SerializeField] private Transform groundCheckRef;

    //Variable [Move]
    [Header("[Move] setting")]
    [SerializeField] private float speed = 10f;
    private Vector3 direction;
    [SerializeField] private Transform orientation;
    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;

    [Header("[Gravity] setting")]
    [SerializeField] private float gravity;
    [SerializeField] private float airMultiplier;
    [SerializeField] private float maxFallVelocity;
    public float velocitycheck;

    
 
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
        
        velocitycheck = rb.velocity.y;
        //Jump System Start
        if(Input.GetKeyDown(KeyCode.Space) && isTouchGround == true)
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

        //move System Start
        SpeedControl();
        float HorizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction = orientation.forward * verticalInput + orientation.right * HorizontalInput;


        //OnFloor and not condition
        if(isTouchGround)
        rb.drag = groundDrag;
        else
        rb.drag = airDrag;
    
        //move System End

    }

    private void FixedUpdate() 
        {
            //Gravity
            if(!isTouchGround)
            {
                rb.AddForce(direction.normalized * speed * 10f * airMultiplier, ForceMode.Force);
                rb.AddForce(transform.up * -gravity);
            }
            else
            rb.AddForce(direction.normalized * speed * 10f , ForceMode.Force);
        }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x , rb.velocity.y , limitedVel.z);
        }

        if(rb.velocity.y <= -maxFallVelocity)
        {
            rb.velocity = new Vector3(rb.velocity.x , -maxFallVelocity , rb.velocity.z);
        }
    }





}
