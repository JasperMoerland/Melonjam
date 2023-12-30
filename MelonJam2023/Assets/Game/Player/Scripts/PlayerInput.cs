using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack, OnJump, Aiming;
    public UnityEvent<float> Onranged;
    private float timer;
    bool timerOn;

    public ContactFilter2D movementFilter;

    private Vector2 movementInput, pointerInput;

    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        Timer();
        OnMovementInput?.Invoke(movementInput);
        OnPointerInput?.Invoke(GetPointerInput());

    }
    public Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void OnMove(InputAction.CallbackContext momentValue)
    {
        movementInput = momentValue.ReadValue<Vector2>().normalized;
    }
    public void OnFire()
    {
        OnAttack?.Invoke();
    }
    public void OnRanged(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            
            timerOn = true;
            Aiming?.Invoke();
            
        }
        if (context.canceled) 
        {

            timerOn = false;
            
            Onranged?.Invoke(timer);
            
            
        }
        
    }

    void Timer()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
        }
    }
    public void OnDash()
    {
        OnJump?.Invoke();
    }
}
