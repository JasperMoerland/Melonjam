using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public GameObject meleePrefab;
    public float delay = 0.5f;

    private bool attackBlocked;
    public Vector2 PointerPosition { get; set; }
    // Update is called once per frame

    private AudioSource audioSound;


    public bool IsAttacking { get; private set; }


    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }

    void Update()
    {
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        
        transform.localScale = scale;
    }

    public void Attack()
    {
        if (attackBlocked)
        {
            return;
        };
        
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
