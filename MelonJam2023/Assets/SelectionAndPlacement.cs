using UnityEngine;

public class SelectionAndPlacement : MonoBehaviour
{
    public Sprite selected;
    public Sprite deselected;
    private SpriteRenderer sprite;
    private Camera mainCamera;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Get the SpriteRenderer component
        sprite = gameObject.GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer component exists
        if (sprite == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
        }
    }

    void Update()
    {
        // Check if the mainCamera is assigned
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        // Create a ray from the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        // Perform the raycast
        if (Physics.Raycast(ray, out hitInfo))
        {
            // Check if the raycast hits this object
            if (hitInfo.collider.gameObject == gameObject)
            {
                // Change the sprite to 'selected' when mouse is hovering
                if (selected != null)
                {
                    sprite.sprite = selected;
                }
                else
                {
                    Debug.LogWarning("Selected sprite not assigned!");
                }
            }
            else
            {
                // Change the sprite to 'deselected' when mouse is not hovering
                if (deselected != null)
                {
                    sprite.sprite = deselected;
                }
                else
                {
                    Debug.LogWarning("Deselected sprite not assigned!");
                }
            }
        }
    }
}
