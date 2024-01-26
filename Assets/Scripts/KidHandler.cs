using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class KidHandler : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // anim.SetBool("happy", true);   
    }

    public void ReceiveObjectName(string objectName)
    {
        Debug.Log("Received object name: " + objectName);

        if (objectName.Equals("Milk"))
        {
            anim.SetBool("happy", true);
        }
    }

}
