using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class st : MonoBehaviour
{

    public string sceneName; // The name of the scene you want to load


    private void OnMouseDown()
    {
            SceneManager.LoadScene(sceneName);

    }
}
