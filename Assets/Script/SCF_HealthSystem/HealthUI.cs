using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;  
    public Sprite halfHeart;  
    public Sprite emptyHeart; 


    public void UpdateHearts(int currentHealth)
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
    
}

