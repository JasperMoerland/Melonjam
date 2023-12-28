using UnityEngine;

public class Selectionand_placement : MonoBehaviour
{
    public Sprite selected;
    public SpriteRenderer sprite;
    public Sprite deselected;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Selection(selected, deselected);
    }
    public void Selection(Sprite Selected, Sprite Deselected)
    {
        Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (sprite.sprite == Deselected)
            {
                sprite.sprite = Selected;
            }


        }
        else
        {
            if (sprite.sprite == Selected)
            {
                sprite.sprite = Deselected;
            }

        }

    }
}
