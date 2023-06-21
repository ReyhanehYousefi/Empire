using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject player;
    public GameObject soldierCard;
    public GameObject rockCard;

    private bool isRockSelected = false;
    public bool destroy = false;
    private void Update()
    {
        // Check if the player is close to the soldier card
        GameObject[] soldierCards = GameObject.FindGameObjectsWithTag("soldier");
            foreach (GameObject soldierCard in soldierCards)
            {
                float distance = Vector2.Distance(player.transform.position, soldierCard.transform.position);
                if (distance < 3f) // Adjust the distance threshold as needed
                {
                    if (isRockSelected)
                    {   
                // Convert the soldier card to a way
                        destroy = true;
                    }else{
                        destroy = false;
                    }
                }
            }
    }

    public void SelectRockCard()
    {
        isRockSelected = true;
    }

    public void DeselectRockCard()
    {
        isRockSelected = false;
    }

    private void ConvertToWay()
    {
        // Remove the soldier card
        Destroy(soldierCard);

        // Create a way card in the same position
        GameObject wayCard = Instantiate(Resources.Load<GameObject>("7"), soldierCard.transform.position, Quaternion.identity);
    }
}
