using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points instance;
    void Awake()
    {
        instance = this;
    }

    public int points;
}
