using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManageScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Your Score is: " + (int)GameManager.realtimer + " seconds";
        GameManager.Score = (int) GameManager.realtimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
