using UnityEngine;

public class Quit : MonoBehaviour
{
    // Update is called once per frame
    void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            QuitGame();
        
        }
    }

    void Update()
    {
        // Check for the quit game input
        
    }

    public void QuitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
