using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class healthmanager : MonoBehaviour
{
    public Image healthimage;
    private float divide = 100.00f;
    public void AddLonely(float amount)
    {
        healthimage.fillAmount += amount/divide;
    }
}
