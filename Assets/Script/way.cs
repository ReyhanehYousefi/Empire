using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class way : MonoBehaviour
{
    public int point = 1;
    public obj gameObj; // Assign the player object in the Unity editor
    private bool isCardSelected = false;
    private bool isCardAdjacent;
    private GameObject myCard; // Declare the GameObject variable
    private Color disabledColor = new Color(0.5f, 0.5f, 0.5f, 0.5f); // Grayed out color
    private Color selectedColor = new Color(0.7f, 0.7f, 0.7f); // Color when card is selected
    private Vector2 playerPosition;
    public map Map;

    public float scaleIncrease = 0.5f; // Scale increase value for adjacent cards

    private Vector2 pos;

    private void Start()
    {
        myCard = gameObject; // Get the GameObject that this script is attached to
        playerPosition = new Vector2(gameObj.transform.position.x, gameObj.transform.position.y);
        Map.pp.Add(playerPosition);
    }

    private void OnMouseDown()
    {
        if (!isCardSelected && Input.GetMouseButtonDown(0))
        {
            if (Map.cont)
            {
                // Check if the card is adjacent to the player card
                isCardAdjacent = IsAdjacentToPlayer();
                Debug.Log("Try to catch ... .");
                if (isCardAdjacent)
                {
                    Debug.Log("Catched !");
                    isCardSelected = true;
                    gameObj.score += point;

                    DisableCard();
                    myCard.GetComponent<Renderer>().material.color = selectedColor;
                    Map.pp.Add(new Vector2(transform.position.x, transform.position.y)); // Store selected card position

                    // Scale adjacent cards
                    ScaleAdjacentCards();
                }
            }
        }
        else if (isCardSelected && Input.GetMouseButtonDown(0))
        {
            pos = Map.pp[Map.pp.Count - 1];

            if (pos.x == transform.position.x && pos.y == transform.position.y)
            {
                // Deselect the card
                isCardSelected = false;
                gameObj.score -= point;

                EnableCard();
                myCard.GetComponent<Renderer>().material.color = Color.white;
                Map.pp.RemoveAt(Map.pp.Count - 1); // Remove the last selected card position

                // Reset the scale of adjacent cards
                ResetAdjacentCardsScale();
            }
        }
    }

    private bool IsAdjacentToPlayer()
    {
        // Get the position of this card
        Vector2 cardPosition = new Vector2(transform.position.x, transform.position.y);

        // Check if the card is adjacent to the player card
        Debug.Log("NOW I'M HERE: " + Map.pp[Map.pp.Count - 1] + " AND YOU CHOSE: " + cardPosition);
        float distance = Vector2.Distance(Map.pp[Map.pp.Count - 1], cardPosition);

        return distance < 10f; // Adjust the value as needed for proximity check
    }

    private void DisableCard()
    {
        Renderer cardRenderer = myCard.GetComponent<Renderer>();
        cardRenderer.material.color = disabledColor; // Set card color to grayed out
        //myCard.GetComponent<Collider>().enabled = false; // Disable card's collider
    }

    private void EnableCard()
    {
        Renderer cardRenderer = myCard.GetComponent<Renderer>();
        cardRenderer.material.color = Color.white; // Reset card color
        //myCard.GetComponent<Collider>().enabled = true; // Enable card's collider
    }

    private void ScaleAdjacentCards()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); // Adjust the radius as needed

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.CompareTag("Card"))
            {
                GameObject adjacentCard = collider.gameObject;
                Vector3 newScale = adjacentCard.transform.localScale + new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
                adjacentCard.transform.localScale = newScale;
            }
        }
    }

    private void ResetAdjacentCardsScale()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); // Adjust the radius as needed

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject.CompareTag("Card"))
            {
                GameObject adjacentCard = collider.gameObject;
                Vector3 originalScale = adjacentCard.GetComponent<way>().GetOriginalScale();
                adjacentCard.transform.localScale = originalScale;
            }
        }
    }

    private Vector3 GetOriginalScale()
    {
        return myCard.transform.localScale;
    }
}
