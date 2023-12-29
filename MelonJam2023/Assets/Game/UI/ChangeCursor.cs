using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D mouseIcon;

    private void Start()
    {
        Cursor.SetCursor(mouseIcon, new Vector2(206,206), CursorMode.Auto);
    }
}
