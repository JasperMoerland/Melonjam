using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float currentHealth, maxHealth;
    public deathManager deathManager;

    [SerializeField]
    private GameObject deathPrefab;

    public UnityEvent<GameObject> OnHitWithReference, OndeathWithReference;

    [SerializeField]
    private bool isDead = false;

    public float delay = 2f;



    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
        {
            return;
        }

        if (sender.layer == gameObject.layer)
        {
            return;
        }

        currentHealth -= amount;


        if (currentHealth > 0)
        {

            OnHitWithReference.Invoke(sender);
        }
        else
        {
            
            isDead = true;
            deathManager.playerDied();
            Instantiate(deathPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
            OndeathWithReference.Invoke(sender);
        }
    }
}
