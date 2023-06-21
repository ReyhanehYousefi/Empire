using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class displaylevelname : MonoBehaviour
{
    public TextMeshProUGUI levelNameText;

    private void Start()
    {
        // Get the active scene's name
        string levelName = SceneManager.GetActiveScene().name;

        // Display the level name in the TextMeshPro text component
        levelNameText.text = "Level : " + levelName;
    }
}
