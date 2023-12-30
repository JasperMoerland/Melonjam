using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class healthmanager : MonoBehaviour
{
    public Health health;
    public Image healthimage;
    private float divide = 100.00f;
    private float loneley;

    private void Update()
    {
        if (health != null)
        {
            loneley = 100 - health.currentHealth;
            AddLonely(loneley);
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
