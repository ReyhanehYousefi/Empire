using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            RestartGame();
            Time.timeScale = 1f;
        }
    }

    private void RestartGame()
    {
        // Implement restart logic here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
