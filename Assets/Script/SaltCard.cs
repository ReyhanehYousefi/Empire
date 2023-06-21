using UnityEngine;

public class SaltCard : MonoBehaviour
{
    public InteractionManager interactionManager;

    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public GameObject way;
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
        GameObject[] ghostCards = GameObject.FindGameObjectsWithTag("ghost");
        foreach (GameObject ghostCard in ghostCards)
        {
            float distance = Vector2.Distance(transform.position, ghostCard.transform.position);

            if (distance < 1f)
            {
                if (gameObj != null) // Check if gameObj is not null
                {
                    float dis = Vector2.Distance(gameObj.transform.position, ghostCard.transform.position);
                    if (dis < 10f)
                    {
                        Destroy(ghostCard);
                        GameObject wayCard = Instantiate(way, ghostCard.transform.position, Quaternion.identity);
                        wayCard.tag = "card"; // Set the tag of the way card to "card"
                        Destroy(gameObject);
                    }
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
