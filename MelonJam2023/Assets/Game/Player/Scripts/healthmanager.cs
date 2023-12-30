using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthmanager : MonoBehaviour
{
    public deathManager deathManager;
    public Health health;
    public Image healthimage;
    private float divide = 100.00f;
    private float loneley;
    private bool isDead = false;
    private void Update()
    {
        if (isDead == true) return;
        if (health != null)
        {
            loneley = 100 - health.currentHealth;
            AddLonely(loneley);
            if (health.currentHealth <= 0)
            {
                isDead = true;
                deathManager.playerDied();
            }
        }

    }

    public void AddLonely(float amount)
    {
        if (healthimage != null)
        {
            healthimage.fillAmount = amount / divide;
        }
    }

}
