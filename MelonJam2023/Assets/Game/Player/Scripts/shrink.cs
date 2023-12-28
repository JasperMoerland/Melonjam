using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour
{
    public float targetSize, growSpeed, fadeSpeed;
    public SpriteRenderer sprite;


    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetSize, targetSize, 1), Time.deltaTime * growSpeed);
        float alpha = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * fadeSpeed);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        if (sprite.color.a < 0.05) Destroy(gameObject);
    }
}
