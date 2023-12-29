using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class EnemyGrow : MonoBehaviour
{
    public float targetSize, growSpeed, fadeSpeed;
    public SpriteRenderer sprite;

    private bool ableToHit = true;

    private void Start()
    {
        if (ableToHit == true)
        {

        }
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

            Health health;

            if (health = collisionEnemy.GetComponentInParent<Health>())
            {
 
                
                    Debug.Log(collisionEnemy);
                    health.GetHit(10, transform.gameObject);
                

            }
            else
            {
                //hit a wall
                //sound
                //gfx
            }

            Destroy(gameObject);
        }
    }
}
