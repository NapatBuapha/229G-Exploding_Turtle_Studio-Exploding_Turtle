using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Variable
    //Variable [Jump]
    [Header("[Jump] setting")]
    [SerializeField] private float jumpForce = 10f;
    public bool isTouchGround;
    [SerializeField] private float checkingDistance = 1f;

    //Object refference
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

    [Header("[Fall Damage] setting")]
    private Player_HealthSystem player_HealthSystem;
    private FallDamageCalculator fallDamageCalculator;

    [Header("[Dying] ref")]
    public bool isDead;
    [SerializeField] private GameObject gameOverUi;



    
 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player_HealthSystem = GetComponent<Player_HealthSystem>();
        fallDamageCalculator = GetComponent<FallDamageCalculator>();
    }
    void Start()
    {
        
        isDead = false;
        isTouchGround = true;
    }

    

    

   
    void Update()
    {   //Dead check start
        if(isDead)
        {
            return;
        }

        if(player_HealthSystem.currentHealth <= 0)
        {
            Dying();
            Debug.Log("Is dead");
            isDead = true;
        }
        //Dead check end

        
        velocitycheck = rb.velocity.y;
        //Jump System Start

        if(Input.GetKey(KeyCode.Space) && isTouchGround == true)
        if(Input.GetKeyDown(KeyCode.Space) && isTouchGround == true)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
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
        //move System End


        //OnFloor and not condition
        if(isTouchGround)
        rb.drag = groundDrag;
        else
        rb.drag = airDrag;
    
        

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

    private void Dying()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverUi.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Items"))
        {
            ICollectable collectable = col.GetComponent<ICollectable>();
            if(collectable != null)
            {
                collectable.collect();
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if(!isTouchGround && collision.collider.CompareTag("Floor"))
        {
            Debug.Log("TakeFall Damage");
            player_HealthSystem.TakeDamage(fallDamageCalculator.fallDamage);
        }
    }





}