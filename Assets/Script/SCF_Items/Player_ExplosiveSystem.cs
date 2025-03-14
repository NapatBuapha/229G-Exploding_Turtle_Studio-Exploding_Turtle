using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player_ExplosiveSystem : MonoBehaviour
{

    [SerializeField] private float radius = 5f;
    [SerializeField] private float explosiveForce = 10f;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Explode();
        }    
    }

    void Explode ()
    {
        Debug.Log("boom");
        //ใส่ effect 

        //ทำให้วัตถุอื่นๆกระเด็น
        Collider[] otherColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in otherColliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosiveForce, transform.position, radius);
            }
        }
    }
}
