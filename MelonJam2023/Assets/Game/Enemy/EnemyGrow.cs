using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class EnemyGrow : MonoBehaviour
{
    public float targetSize, growSpeed, fadeSpeed;
    public SpriteRenderer sprite;

    private bool ableToHit = true;
    private new Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetSize, targetSize, 1), Time.deltaTime * growSpeed);
        float alpha = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * fadeSpeed);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        if (sprite.color.a < 0.5) ableToHit = false;
        if (sprite.color.a < 0.05) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collisionEnemy)
    {
        {

            if (collisionEnemy.gameObject.name == "Enemy") return;
            if (collisionEnemy.gameObject.layer == gameObject.layer) return;
            Destroy(gameObject);
        }
    }
}
