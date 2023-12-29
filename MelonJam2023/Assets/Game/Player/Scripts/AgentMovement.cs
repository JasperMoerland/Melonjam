using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public Vector2 MovementInput;

    bool IsMoving
    {
        set
        {
            isMoving = value;
        }
    }


    bool isMoving = false;

    Rigidbody2D rb;

    public float maxSpeed = 2.2f;
    public float moveSpeed = 700f;

    public float collisionOffset = 0.05f;

    public float idleFriction = 0.9f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (MovementInput != Vector2.zero)
        {

            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (MovementInput * moveSpeed * Time.deltaTime), maxSpeed);

            IsMoving = true;
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            IsMoving = false;
        }
        Vector2 direction = (rb.velocity).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;

        transform.localScale = scale;
    }
}
