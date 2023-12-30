using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Health playerHealth;
    public TextMeshProUGUI Friends;
    public int reward;
    private int points = 0;
    public void Die()
    {
        Points.instance.points += 1;
        points = Points.instance.points;
        Debug.Log(playerHealth.currentHealth);
        playerHealth.currentHealth += reward;
        if (playerHealth.currentHealth > playerHealth.maxHealth) { playerHealth.currentHealth = playerHealth.maxHealth; }
        Debug.Log(playerHealth.currentHealth);
        if (Friends != null){
            Friends.text = points.ToString();
            
        }
        //sound and gfx
    }
}
