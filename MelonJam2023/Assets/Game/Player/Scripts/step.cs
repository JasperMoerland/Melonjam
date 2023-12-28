using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class step : MonoBehaviour
{
    public float delay = 0.3f;
    public GameObject stepPrefab;
    private void Start()
    {
        StartCoroutine(Steps());

    }
    private IEnumerator Steps()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(stepPrefab, transform.position, transform.rotation, null);
        }
    }

}
