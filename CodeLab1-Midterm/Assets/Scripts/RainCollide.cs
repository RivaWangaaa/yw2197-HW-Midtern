using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollide : MonoBehaviour
{
    public static int rainCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {

            print("HIT Rain!!");
            GameManager.instance.GetComponent<ASCIILoader>().ResetPlayer();
            Destroy(gameObject);
        }
        else if (other.gameObject.name.Contains("Goal"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name.Contains("Umbrella"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name.Contains("Wall")){

            Destroy(gameObject);
        }
    }
}
