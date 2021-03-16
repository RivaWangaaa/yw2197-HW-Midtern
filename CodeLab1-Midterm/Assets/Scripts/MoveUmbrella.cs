using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUmbrella : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag() //if the mouse is dragged on the gameObject
    {
        //set it's position to where ever it was dragged
        transform.position = GetMouseWorldPosition();
    }
    

    Vector3 GetMouseWorldPosition() //turn the screen position into a world position
    {
        //get the screen position of the mouse
        Vector3 mousePosition = Input.mousePosition;

        //set the z of the mouse based on the world positon of the gameObject
        mousePosition.z = 
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //return the transformed ScreenToWorldPoint of the mouse, based on the gameObjects z
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
