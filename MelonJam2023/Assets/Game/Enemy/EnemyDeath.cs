using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Health playerHealth;
    public GameObject Friends;
    public int reward;
    private int points = 0;
    public void Die()
    {
        points += 1;
        if (Friends != null){
            Friends.GetComponent<TextMeshProUGUI>().text = points.ToString();
            playerHealth.currentHealth += reward;
        }
        //sound and gfx
    }
}
