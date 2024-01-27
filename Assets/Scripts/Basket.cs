using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {

        
        // Turn right
        if(Input.GetKey("right") == true)
        {
            if (tr.position.x < 4f)
            {
                tr.position += new Vector3(0.2f, 0f, 0f);
                transform.localScale = Vector3.one;
            }
        }

        // Turn left
        if (Input.GetKey("left") == true)
        {
            
            if (tr.position.x > -4f)
            {
                tr.position += new Vector3(-0.2f, 0f, 0f);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}