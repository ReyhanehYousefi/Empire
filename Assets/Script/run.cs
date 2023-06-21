using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class run : MonoBehaviour
{
    public map Map;
    public obj gameObj;
    private int currentIndex = 0;
    private bool isMoving = false;
    private GameObject but; // Declare the GameObject variable

    private Vector2 playerPosition;

    // is game over
    private bool igo = false;
    public LEVELCENTER l;

    private void Start()
    {
        StartMoving();
    }

    private void StartMoving()
    {
        if (Map.pp.Count > 2)
        {
            currentIndex = 0;
            isMoving = true;
            StartCoroutine(MoveObject());
        }
    }

    private IEnumerator MoveObject()
    {
        while (currentIndex < Map.pp.Count)
        {
            Vector2 targetPosition = Map.pp[currentIndex];
            float distance = Vector2.Distance(gameObj.transform.position, targetPosition);

            while (distance > 0.0f)
            {
                // Move towards the target position with a speed of 5
                gameObj.transform.position = Vector2.MoveTowards(gameObj.transform.position, targetPosition, 10f * Time.deltaTime);
                distance = Vector2.Distance(gameObj.transform.position, targetPosition);
                if (Mathf.Approximately(distance, 0.0f))
                {
                    // Distance is approximately zero, check for cards with tag name "way" and delete them
                    GameObject[] wayCards = GameObject.FindGameObjectsWithTag("card");
                    foreach (GameObject card in wayCards)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            Destroy(card);
                        }
                    }

                    GameObject[] spellCards = GameObject.FindGameObjectsWithTag("spell");
                    foreach (GameObject card in spellCards)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            Destroy(card);
                        }
                    }

                    GameObject[] soldierCards = GameObject.FindGameObjectsWithTag("soldier");
                    foreach (GameObject card in soldierCards)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            if (gameObj.score >= 0)
                            {
                                Destroy(card);
                                igo = false;
                            }
                            else
                            {
                                Destroy(card);
                                igo = true;
                            }
                        }
                    }

                    GameObject[] exitCard = GameObject.FindGameObjectsWithTag("exit");
                    foreach (GameObject card in exitCard)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            // Go to the next level
                            string currentLevelName = SceneManager.GetActiveScene().name;

                            // Check if the current level is level 1 and update LEVELCENTER accordingly
                            Debug.Log(currentLevelName);
                            if (currentLevelName == "1")
                            {
                                LEVELCENTER.Instance.lev.Add("1");
                                LEVELCENTER.Instance.lev.Add("2");
                            }
                            else if (currentLevelName == "2")
                            {
                                LEVELCENTER.Instance.lev.Add("3");
                            }
                            else if (currentLevelName == "3")
                            {
                                #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
                            }

                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            yield break; // Exit the coroutine
                        }
                    }

                    GameObject[] adamCard = GameObject.FindGameObjectsWithTag("adam");
                    foreach (GameObject card in adamCard)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            if (gameObj.score >= 0 && (gameObj.tag == "lica" || gameObj.tag == "fox"))
                            {
                                Destroy(card);
                            }
                            else
                            {
                                GameOver();
                            }
                        }
                    }

                    GameObject[] ghostCard = GameObject.FindGameObjectsWithTag("ghost");
                    foreach (GameObject card in ghostCard)
                    {
                        if (card.transform.position == gameObj.transform.position)
                        {
                            if (gameObj.score >= 0 && (gameObj.tag == "lica" || gameObj.tag == "fox"))
                            {
                                Destroy(card);
                            }
                            else
                            {
                                GameOver();
                            }
                        }
                    }
                }
                yield return null;
            }

            currentIndex++;
        }

        Map.pp.Clear();
        playerPosition = new Vector2(gameObj.transform.position.x, gameObj.transform.position.y);
        Map.pp.Add(playerPosition);
        isMoving = false;
        if (igo == true)
        {
            GameOver();
        }
    }

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            // Check for mouse click to start moving again
            StartMoving();
        }
    }

    public GameObject go;

    void GameOver()
    {
        go.SetActive(true);
    }
}
