using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public List<Vector2> pp = new List<Vector2>();
    
    public float arrowWidth = 0.1f;
    public float arrowLength = 1f;
    public float arrowHeadAngle = 20f;
    
    //continue pathing
    public bool cont = true;
    public obj gameObj;
    public Color arrowColor;
    public Material arrowMaterial;
    private List<GameObject> arrowObjects = new List<GameObject>();
    
    private void Start()
    {
    }

    private void Update()
    {
        // Clear any previously created arrow objects
        ClearArrows();
        if(gameObj.score<0){
            cont = false;
        }else{
            cont = true;
        }
        // Make sure there are enough positions to create pairs
        if (pp.Count < 2)
        {
            return;
        }

        // Iterate over pairs of positions and create arrows
        for (int i = 0; i < pp.Count - 1; i++)
        {
            Vector3 startMarker = pp[i];
            Vector3 endMarker = pp[i + 1];
            CreateArrow(startMarker, endMarker);
        }
    }

    private void CreateArrow(Vector3 startMarker, Vector3 endMarker)
{
    Vector3 arrowDirection = (endMarker - startMarker).normalized;
    Vector3 arrowHeadOffset = arrowDirection * arrowLength;

    Vector3 arrowHeadLeft = Quaternion.Euler(0, -arrowHeadAngle, 0) * -arrowDirection;
    Vector3 arrowHeadRight = Quaternion.Euler(0, arrowHeadAngle, 0) * -arrowDirection;

    // Calculate arrow points
    Vector3[] arrowPoints = new Vector3[4];
    arrowPoints[0] = startMarker;
    arrowPoints[3] = endMarker;
    arrowPoints[1] = endMarker - arrowHeadOffset + arrowHeadLeft * arrowWidth;
    arrowPoints[2] = endMarker - arrowHeadOffset + arrowHeadRight * arrowWidth;

    // Create a new game object for the arrow
    GameObject arrowObject = new GameObject("Arrow");
    arrowObject.transform.position = startMarker;

    // Add a LineRenderer component to the arrow object
    LineRenderer lineRenderer = arrowObject.AddComponent<LineRenderer>();
    lineRenderer.startWidth = arrowWidth;
    lineRenderer.endWidth = arrowWidth;

    // Set the positions for the line renderer
    lineRenderer.positionCount = arrowPoints.Length;
    lineRenderer.SetPositions(arrowPoints);

    // Set the color of the arrow to yellow
    lineRenderer.material.color = arrowColor;
    lineRenderer.material = arrowMaterial;

    // Add the arrow object to the list
    arrowObjects.Add(arrowObject);
}


    private void ClearArrows()
    {
        // Destroy all arrow game objects
        foreach (GameObject arrowObject in arrowObjects)
        {
            Destroy(arrowObject);
        }

        // Clear the list
        arrowObjects.Clear();
    }

    // Other methods and event handlers...

}
