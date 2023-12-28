using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;
    public UnityEvent OnJump;

    public ContactFilter2D movementFilter;

    private Vector2 movementInput, pointerInput;

    [SerializeField]
    private InputAction Fire;
    private void Update()
    {
        OnMovementInput?.Invoke(movementInput);
        OnPointerInput?.Invoke(GetPointerInput());

    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnMove(InputValue momentValue)
    {
        
        movementInput = momentValue.Get<Vector2>().normalized;
    }
    void OnFire()
    {
        OnAttack?.Invoke();
    }
    void OnDash()
    {
        OnJump?.Invoke();
    }
}
