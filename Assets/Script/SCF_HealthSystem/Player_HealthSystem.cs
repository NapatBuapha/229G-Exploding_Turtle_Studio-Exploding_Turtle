using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HealthSystem : MonoBehaviour
{
    [SerializeField] private AudioClip hitFX;
    private AudioSource audioSource;

    public int maxHealth;

    public int currentHealth = 20;

    HealthUI healthUI;

    private void Awake()
    {
        healthUI = GameObject.Find("Health_UI_Canvas").GetComponent<HealthUI>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth);
    }

        public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            audioSource.clip = hitFX;
            audioSource.Play();
        }        
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthUI.UpdateHearts(currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthUI.UpdateHearts(currentHealth);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) // กด Spacebar เพื่อลด HP
        {
            TakeDamage(2);
            Debug.Log($"🔥 HP ลดลง! ตอนนี้เหลือ {currentHealth} HP");
        }
        if (Input.GetKeyDown(KeyCode.H)) // กด H เพื่อ Heal
        {
            Heal(2);
            Debug.Log($"💖 HP เพิ่มขึ้น! ตอนนี้เหลือ {currentHealth} HP");
        }
        if (Input.GetKeyDown(KeyCode.G)) // กด G เพื่อ Heal 1 หน่วย
        {
            Heal(1);
            Debug.Log($"💖 HP เพิ่มขึ้น! ตอนนี้เหลือ {currentHealth} HP");
        }
        */

    }
}
