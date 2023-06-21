using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVELCENTER : MonoBehaviour
{
    private static LEVELCENTER instance;
    public List<string> lev = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            // If the instance is null, set this object as the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    public static LEVELCENTER Instance
    {
        get { return instance; }
    }

    // Other methods and functionality of the global object
    void Start()
    {

    }

    void Update()
    {

    }
}
