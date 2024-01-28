using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Transform tr;
    [SerializeField] private AudioSource walkSoundEffect;

    private void Start()
    {
        tr = GetComponent<Transform>();
        PlayerPrefs.SetInt("scoreboard", 0);
    }

    private void FixedUpdate()
    {

        
        // Turn right
        if(Input.GetKey("right") == true)
        {
            walkSoundEffect.Play();

            if (tr.position.x < 4f)
            {
                tr.position += new Vector3(0.2f, 0f, 0f);
                transform.localScale = new Vector3(1.5f,1.5f,1f);
            }
        }

        // Turn left
        if (Input.GetKey("left") == true)
        {
            walkSoundEffect.Play();

            if (tr.position.x > -4f)
            {
                tr.position += new Vector3(-0.2f, 0f, 0f);
                transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
            }
        }
    }

}