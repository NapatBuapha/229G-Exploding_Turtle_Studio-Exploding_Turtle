using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player_ExplosiveSystem : MonoBehaviour
{

    [SerializeField] private float radius = 5f;
    [SerializeField] private float explosiveForce = 10f;
    [SerializeField] private GameObject explosiveEffect;
    [SerializeField] private AudioClip explosiveFX;
    private AudioSource audioSource;

    [Header ("Explosive Items")]
    public int exploAmout;
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && exploAmout > 0)
        {
            exploAmout--;
            Explode();
        }    
    }

    void Explode ()
    {
        audioSource.clip = explosiveFX;
        audioSource.Play();
        Instantiate(explosiveEffect,transform.position,quaternion.identity);
        //ใส่ effect 
        
        //ทำให้วัตถุอื่นๆกระเด็น
        Collider[] otherColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in otherColliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddExplosionForce(explosiveForce, transform.position, radius);
            }
        }
    }
}
