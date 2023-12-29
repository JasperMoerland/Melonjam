using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;

    public float baseMoveSpeed, maxChargeTime, extraMoveSpeed;
    private float moveForce;
    private Vector2 Movedirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void SetupBullet(Vector2 dir, float shootTime)
    {
        moveForce = baseMoveSpeed + Mathf.Clamp(shootTime, 0f, 3) * extraMoveSpeed;
        Movedirection = dir;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Movedirection.normalized * moveForce;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        {


            if (collider.gameObject.name == "Player") return;
            if (collider.gameObject.layer == gameObject.layer) return;

            Health health;

            if (health = collider.GetComponentInParent<Health>())
            {
                if (collider.CompareTag("HitBox"))
                {
                    Debug.Log(collider);
                    health.GetHit(1, transform.gameObject);
                }

            }
            else
            {
                //hit a wall
                //sound
                //gfx
            }

        }
    }
}
