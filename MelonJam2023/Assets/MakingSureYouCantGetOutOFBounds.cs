using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakingSureYouCantGetOutOFBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -200)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.x >= 140)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.y >= 86)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.y <= -108)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
