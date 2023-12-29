using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateMouse : MonoBehaviour
{
    public float strength = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = GetPointerInput();
        transform.Rotate(new Vector3( 0, 0, strength * Time.deltaTime));
    }
    public Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
