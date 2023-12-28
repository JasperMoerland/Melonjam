using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerController : MonoBehaviour
{

    public ContactFilter2D movementFilter;

    private Vector2 movementInput, pointerInput;

    private AgentMovement agentMover;

    private WeaponRotation weaponParent;
    public TrailRenderer trailRenderer;

    public float dashDelay = 0.3f;
    public float dashWait = 2f;
    private bool Dashed = false;



    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }

    Rigidbody2D rb;


    private void Start()
    {
        weaponParent = GetComponentInChildren<WeaponRotation>();
        agentMover = GetComponent<AgentMovement>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        weaponParent.PointerPosition = pointerInput;

        
        agentMover.MovementInput = movementInput;
    }

    public void Dash()
    {
        if (Dashed)
        {
            return;
        }
        Dashed = true;
        agentMover.maxSpeed = agentMover.maxSpeed * 4;
        //trailRenderer.emitting = true;
        StartCoroutine(ResetDash());
        StartCoroutine(EnableDash());

    }

    private IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(dashDelay);
        //trailRenderer.emitting = false;
        agentMover.maxSpeed = agentMover.maxSpeed / 4;
    }
    private IEnumerator EnableDash()
    {
        yield return new WaitForSeconds(dashWait);
        Dashed = false;

    }

    public void PerformAttack()
    {
        weaponParent.Attack();

    }
}
