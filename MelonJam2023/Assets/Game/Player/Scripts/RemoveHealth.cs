using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHealth : MonoBehaviour
{
    Health health;
    private void Start()
    {
        health = GetComponent<Health>();
        StartCoroutine(lonely());

    }
    private IEnumerator lonely()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            health.currentHealth -= 1;
        }
    }
}
