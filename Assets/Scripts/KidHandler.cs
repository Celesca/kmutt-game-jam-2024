using UnityEngine;
using System.Collections;

public class KidHandler : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ReceiveObject(GameObject clickedObject)
    {
        Debug.Log("Kid Received object: " + clickedObject.name);

        if (clickedObject.name == "Milk" || clickedObject.name == "")
        {
            int easterEggCount = PlayerPrefs.GetInt("EasterEggCount");
            anim.SetBool("happy", true);
            StartCoroutine(ResetHappyStateAfterDelay(2.0f));
            // No need to wait, destroy the game object immediately
            Destroy(clickedObject);
            // Save a variable
            PlayerPrefs.SetInt("EasterEggCount", easterEggCount + 1);
            Debug.Log(easterEggCount + 1);
        }
    }

    private IEnumerator ResetHappyStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("happy", false);
    }
}