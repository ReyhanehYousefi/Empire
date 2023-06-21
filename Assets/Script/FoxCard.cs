using UnityEngine;

public class FoxCard : MonoBehaviour
{
    public InteractionManager interactionManager;
    public Sprite foxSprite; // Reference to the fox sprite

    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

    public GameObject gameObj;

    private void Start()
    {
        // Find the InteractionManager script in the scene
        interactionManager = FindObjectOfType<InteractionManager>();
        startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        // Check if the InteractionManager script is found
        if (interactionManager != null)
        {
            // Call the SelectRockCard method in the InteractionManager script
            interactionManager.SelectRockCard();
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0f;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        // Check if the InteractionManager script is found
        if (interactionManager != null)
        {
            // Call the DeselectRockCard method in the InteractionManager script
            interactionManager.DeselectRockCard();
        }
        GameObject[] licaCards = GameObject.FindGameObjectsWithTag("lica");
        foreach (GameObject licaCard in licaCards)
        {
            float distance = Vector2.Distance(transform.position, licaCard.transform.position);

            if (distance < 1f)
            {
                if (gameObj != null) // Check if gameObj is not null
                {
                    // Change the sprite and tag of the lica card
                    SpriteRenderer licaSpriteRenderer = licaCard.GetComponent<SpriteRenderer>();
                    if (licaSpriteRenderer != null)
                    {
                        licaSpriteRenderer.sprite = foxSprite; // Change the sprite to the fox sprite
                    }
                    licaCard.tag = "fox"; // Change the tag to "fox"
                    Destroy(gameObject);
                }
            }
        }
        if (isDragging)
        {
            isDragging = false;
            transform.position = startPosition;
        }
    }
}
