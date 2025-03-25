using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTNT : MonoBehaviour , ICollectable
{
    [SerializeField] private int amout = 1;
    Player_ExplosiveSystem player_ExplosiveSystem;
    void Start()
    {
        player_ExplosiveSystem = GameObject.Find("Explosive").GetComponent<Player_ExplosiveSystem>();
    }

    public void collect()
    {
        player_ExplosiveSystem.exploAmout += amout;
        Destroy(gameObject);
    }





}
