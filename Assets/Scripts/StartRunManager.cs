using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartRunManager : MonoBehaviour
{
    public Text startupText;
    public float displayDuration = 2f;

    private void Start()
    {
        StartCoroutine(StartupSequence());
    }

    public IEnumerator StartupSequence()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Display text
        startupText.gameObject.SetActive(true);

        // Wait for display duration
        yield return new WaitForSeconds(displayDuration);

        // Close text
        startupText.gameObject.SetActive(false);

        // Start the main game or enable other components
        // For example, you might want to activate the ObjectMovement script here.
    }
}