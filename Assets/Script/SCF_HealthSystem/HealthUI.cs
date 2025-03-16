using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public int maxHealth = 20; 
    public int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;  
    public Sprite halfHeart;  
    public Sprite emptyHeart; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int heartValue = (i + 1) * 2;

            if (currentHealth >= heartValue)
            {
                hearts[i].sprite = fullHeart; 
            }
            else if (currentHealth == heartValue - 1)
            {
                hearts[i].sprite = halfHeart; 
            }
            else
            {
                hearts[i].sprite = emptyHeart; 
            }
        }
    }
    void Update()
    {
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
    }
}

