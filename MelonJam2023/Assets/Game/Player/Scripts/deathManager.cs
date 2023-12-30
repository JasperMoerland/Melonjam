using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public void playerDied()
    {
        Debug.Log("Died");
        gameOverUI.SetActive(true);
    }
}
