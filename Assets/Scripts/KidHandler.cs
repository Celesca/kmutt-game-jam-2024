using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class KidHandler : MonoBehaviour
{
    private Animator anim;
    public Text babyText;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerPrefs.SetInt("ItemCount", 0);
    }

    public void ReceiveObject(GameObject clickedObject)
    {
        Debug.Log("Kid Received object: " + clickedObject.name);

        if (clickedObject.name.Length > 0)
        {

            if (clickedObject.name == "Egg")
            {
                clickedObject.SetActive(false);
                int easterEggCount = PlayerPrefs.GetInt("EasterEggCount");
                PlayerPrefs.SetInt("EasterEggCount", easterEggCount + 1);
                Debug.Log(easterEggCount + 1);
                babyText.text = "YUCKK!!\r\nWHY THIS EGG\r\nSO BITTER!!";
                anim.SetBool("yuck", true);
                StartCoroutine(ResetYuckStateAfterDelay(2.0f));
                clickedObject.SetActive(true);
            }
            else
            {
                anim.SetBool("happy", true);
                StartCoroutine(ResetHappyStateAfterDelay(2.0f));
                // No need to wait, destroy the game object immediately
                Destroy(clickedObject);

                if (clickedObject.name == "Bank")
                {
                    babyText.text = "I LOVE MONEY!!\r\nSO, I CAN BUY\r\nWHEY PROTEIN";

                }
                else if (clickedObject.name == "Phone")
                {
                    babyText.text = "THANKS!!\r\nI LOVE PLAYING\r\nROBUX!!";

                }
                else if (clickedObject.name == "Snack")
                {
                    babyText.text = "YUM YUM!!\r\nTHIS CHIPS IS\r\nA BIT CHIP CHIP!";

                }
                else if (clickedObject.name == "Milk")
                {
                    babyText.text = "NOT BAD!!\r\nI LOVE PACIFIER!!\r\n100% MOISTURE";
                    
                }
            }
            

        }
    }

    private IEnumerator ResetYuckStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("yuck", false);
    }

    private IEnumerator ResetHappyStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("happy", false);
        PlayerPrefs.SetInt("ItemCount", PlayerPrefs.GetInt("ItemCount") + 1);

        if (PlayerPrefs.GetInt("ItemCount") == 4)
        {
            anim.SetBool("happy", true);
        }
    }
}