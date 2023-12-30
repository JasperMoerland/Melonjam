using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathManager : MonoBehaviour
{
    public TextMeshProUGUI friendsMade;
    public TextMeshProUGUI scoreDisplay;
    public GameObject gameOverUI;
    public void playerDied()
    {
        if (friendsMade.text == "1")
        {
            scoreDisplay.text = "You made " + friendsMade.text + " Friend!";
        } else
        {
            scoreDisplay.text = "You made " + friendsMade.text + " Friends!";
        }
        
        Debug.Log("Died");
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
