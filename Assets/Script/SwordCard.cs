using UnityEngine;

public class  SwordCard : MonoBehaviour
{
    public InteractionManager interactionManager;

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
        GameObject[] foxes = GameObject.FindGameObjectsWithTag("fox");
        foreach (GameObject fox in foxes)
        {
            float distance = Vector2.Distance(transform.position, fox.transform.position);

            if (distance < 1f)
{
    if (gameObj != null)
    {
        obj gameObjScript = gameObj.GetComponent<obj>();
        if (gameObjScript != null)
        {
            gameObjScript.score += 5; // Increase the score by 5
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
