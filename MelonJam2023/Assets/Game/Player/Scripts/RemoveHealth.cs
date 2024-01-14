using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHealth : MonoBehaviour
{
    PlayerHealth health;
    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        StartCoroutine(lonely());
    }
    private IEnumerator lonely()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            health.currentHealth -= 1;
        }
    }
}