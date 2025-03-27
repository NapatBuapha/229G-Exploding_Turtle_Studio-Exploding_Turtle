using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTNT : MonoBehaviour , ICollectable
{
    [SerializeField] private int amout = 1;
    [SerializeField] private float spinSpeed = 5;
    Player_ExplosiveSystem player_ExplosiveSystem;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_ExplosiveSystem = GameObject.Find("Explosive").GetComponent<Player_ExplosiveSystem>();
    }

    public void collect()
    {
        player_ExplosiveSystem.exploAmout += amout;
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.AddTorque(Vector3.up * spinSpeed);
    }





}
