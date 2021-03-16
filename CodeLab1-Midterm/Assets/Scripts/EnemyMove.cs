using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float forceAmount = 50;

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector2.left * forceAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Player"))
       {
           if (PlayerClick.safeCount == 0)
           {
               print("HIT!!");
               GameManager.instance.GetComponent<ASCIILoader>().ResetPlayer();
           }
           Destroy(gameObject);
       }
        else if (other.gameObject.name.Contains("Goal"))
        {
            Destroy(gameObject);
        }
    }
}
