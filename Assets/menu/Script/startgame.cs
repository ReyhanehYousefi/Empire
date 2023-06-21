using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public string sceneName; // The name of the scene you want to load

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
