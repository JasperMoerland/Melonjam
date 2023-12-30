using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashFeedback : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer circle;

    [SerializeField]
    private float delay = 0.1f;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        circle.color = Color.white;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        circle.color = Color.black;
    }
}
