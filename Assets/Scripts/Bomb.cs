using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    Transform tr;
 
    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y <-7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
            Destroy(this.gameObject);
            
        }
    }
}
