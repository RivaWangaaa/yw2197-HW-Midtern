using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public static int safeCount = 0;
    

    private SpriteRenderer renderer;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer == 1 && safeCount == 1)
        {
            safeCount = 0;
            renderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        renderer.color = Color.yellow;
        safeCount = 1;
        timer = 0;

    }
}
