using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponRotation : MonoBehaviour
{
    public GameObject meleePrefab;
    public GameObject bulletPrefab;
    public float delay = 0.5f;

    private bool attackBlocked;
    public Vector2 PointerPosition { get; set; }
    // Update is called once per frame



    public bool IsAttacking { get; private set; }
    public bool IsAiming { get; set; }
    public SpriteRenderer sprite;
    public void ResetIsAttacking()
    {
        IsAttacking = false;
    }
    Vector2 direction;
    public float fadeSpeed = 2;
    void Update()
    {
        if (IsAiming)
        {
            float alpha = Mathf.Lerp(sprite.color.a, 1, Time.deltaTime / fadeSpeed);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        
        transform.localScale = scale;

        
    }

    public void Attack()
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

    public void RangedAttack(float charge)
    {
        IsAiming = false;
        if (attackBlocked)
        {
            return;
        }
        Debug.Log("RangedAttack");

        Vector2 shootdir = direction;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(Vector3.zero), null);
        bullet.transform.right = shootdir;
        bullet.GetComponent<Bullet>().SetupBullet(shootdir, charge);

        IsAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    
}
