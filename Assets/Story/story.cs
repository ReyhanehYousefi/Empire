using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class story : MonoBehaviour
{
    public TextMeshProUGUI TEXT;
    public string matn = "Once upon a time..."; // Story text
    public float delay = 0.05f;
    public bool active = false;
    public GameObject start;
    void Start()
    {
        StartCoroutine(WriteStory());
    }

    IEnumerator WriteStory()
    {
        for (int i = 0; i < matn.Length; i++)
        {
            TEXT.text += matn[i];
            yield return new WaitForSeconds(delay);
        }
        
        // After writing the story, activate the game object
        start.SetActive(true);
        active = true;
    }
}
