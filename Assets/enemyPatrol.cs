using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemyPatrol : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public Text startupText;
    public bool isRunning = false;
    private Animator anim;

    private void Start()
    {
        Debug.Log("Start");
        StartCoroutine(StartupSequence());
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Move the object to the right along the X-axis
        if (isRunning) {
            anim.SetBool("enemyRunning", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("enemyRunning", false);
        }

  
        
    }

    public IEnumerator StartupSequence()
    {
        // Wait for 3 seconds

        // Close text
        startupText.text = "Why she follow me!?\r\nOMG!!!";
        startupText.gameObject.SetActive(true);

        
        isRunning = true;

        yield return new WaitForSeconds(2f);
        startupText.gameObject.SetActive(false);





        // Start the main game or enable other components

        // For example, you might want to activate the ObjectMovement script here.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Trigger");
        // Check if the trigger is with an object tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Perform actions when enemy enters the trigger zone of the player
            HandleCollisionWithPlayer(other.gameObject);

            // Optionally, you can also disable the enemy or perform other actions.
            // For example, you might want to play a sound or decrease player health.
        }
    }

    void HandleCollisionWithPlayer(GameObject player)
    {
        // Implement the actions to be performed when enemy enters the trigger zone of the player
        Debug.Log("Enemy collided with the player!");

        // Add your custom logic here, such as decreasing player health, playing sound, etc.
    }
}