using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamageCalculator : MonoBehaviour
{
    PlayerController playerController;
    Player_HealthSystem player_Health;
    [SerializeField] private float onAirTime;
    
    public int fallDamage;
    
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        player_Health = GetComponent<Player_HealthSystem>();
    }

    void FixedUpdate()
    {
        fallDamage = fallDamageCalculting();
    }

    public int fallDamageCalculting()
    {
        fallDamage = (int)Mathf.Round(-playerController.velocitycheck / 3) -5;
        if(fallDamage < 0)
        fallDamage = 0;
        return fallDamage;
    }

}
