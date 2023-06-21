using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class obj : MonoBehaviour
{

    public int score = 10;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Updatetext();
        
    }

    void Updatetext(){
        scoreText.text = "Score : "+score.ToString();
    }

    

    
}
