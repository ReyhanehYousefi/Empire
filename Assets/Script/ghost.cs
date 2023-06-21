using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public int point = 15;
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
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCardSelected)
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
                        if (gameObj.tag != "fox")
                        {
                            gameObj.score -= point;
                        }
                        else
                        {
                            gameObj.score -= (point / 2);
                        }

                        DisableCard();
                        myCard.GetComponent<Renderer>().material.color = selectedColor;
                        Map.pp.Add(new Vector2(transform.position.x, transform.position.y)); // Store selected card position

                        // Scale adjacent cards
                    }
                }
            }
            else
            {
                pos = Map.pp[Map.pp.Count - 1];

                if (pos.x == transform.position.x && pos.y == transform.position.y)
                {
                    // Deselect the card
                    isCardSelected = false;
                    if (gameObj.tag != "fox")
                    {
                        gameObj.score += point;
                    }
                    else
                    {
                        gameObj.score += (point / 2);
                    }
                    EnableCard();
                    myCard.GetComponent<Renderer>().material.color = Color.white;
                    Map.pp.RemoveAt(Map.pp.Count - 1); // Remove the last selected card position

                    // Reset the scale of adjacent cards
                }
            }
        }
    }

    private bool IsAdjacentToPlayer()
    {
        // Get the position of this card
        Vector2 cardPosition = new Vector2(transform.position.x, transform.position.y);

        // Check if the card is adjacent to the player card
        Debug.Log("NOW I'M HERE : " + Map.pp[Map.pp.Count - 1] + " AND YOU CHOSE : " + cardPosition);
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
}
