using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints instance;
    public int points;
    void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    
}
