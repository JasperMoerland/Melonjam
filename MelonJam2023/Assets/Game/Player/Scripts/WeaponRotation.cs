using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    Animator animator;
    public float delay = 0.5f;
    public SpriteRenderer characterRenderer, weaponRenderer;

    private bool attackBlocked;
    public Vector2 PointerPosition { get; set; }
    // Update is called once per frame

    private AudioSource audioSound;

    private void Start()
    {

        audioSound = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    public bool IsAttacking { get; private set; }

    public Transform circleOrigin;
    public float radius;

    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    void Update()
    {
        if (IsAttacking == true)
        {
            return;
        }

        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x >= 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = -1;
        }
        else
        {
            weaponRenderer.sortingOrder = 1;
        }
    }

    public void Attack()
    {
        if (attackBlocked)
        {
            return;
        }
        audioSound.Play();
        animator.SetTrigger("swordAttack");
        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {

            
        }
    }
}
