using UnityEngine;

public class levels : MonoBehaviour
{
    public GameObject lev1;
    public GameObject lev2;
    public GameObject lev3;

    private LEVELCENTER levelCenter; // Reference to the LEVELCENTER instance

    private void Start()
    {
        GameObject levelCenterObject = GameObject.FindWithTag("LEVELCENTER");
        levelCenter = levelCenterObject.GetComponent<LEVELCENTER>();
    }

    private void Update()
    {
        bool lvl1 = levelCenter.lev.Contains("1");
        bool lvl2 = levelCenter.lev.Contains("2");
        bool lvl3 = levelCenter.lev.Contains("3");

        lev1.SetActive(lvl1);
        lev2.SetActive(lvl2);
        lev3.SetActive(lvl3);
    }
}
