using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[SelectionBase]
public class AgentController : MonoBehaviour
{
    public GameObject meleePrefab;
    public ContactFilter2D movementFilter;

    private Vector2 movementInput;

    private AgentMovement agentMover;

    private WeaponRotation weaponParent;

    public float delay = 0.5f;
    private bool attackBlocked;
    public bool IsAttacking { get; private set; }

    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    SpriteRenderer spriterenderer;

    Rigidbody2D rb;

    private void Start()
    {
        weaponParent = GetComponentInChildren<WeaponRotation>();
        agentMover = GetComponent<AgentMovement>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        agentMover.MovementInput = movementInput;
    }
    public void PerformAttack()
    {
        if (attackBlocked)
        {
            return;
        }

        IsAttacking = true;
        attackBlocked = true;
        Instantiate(meleePrefab, transform.position, transform.rotation, null);
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
