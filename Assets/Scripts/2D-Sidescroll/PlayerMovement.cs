using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float normalSpeed;

    public float speed = 5f;
    private Rigidbody2D body;
    private Animator anim;
    public Text startupText;
    public bool canRunning = false;

    private void Start()
    {
        Debug.Log("Start");
        StartCoroutine(StartupSequence());
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        // Grabs references for rigidbody and animator from the game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
            if (canRunning)
            {
            body.velocity = new Vector2(horizontalInput * normalSpeed, body.velocity.y);

            if (horizontalInput > 0.01f)
                transform.localScale = Vector3.one;
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        
            }
        anim.SetBool("Run", horizontalInput != 0);
    }
    public IEnumerator StartupSequence()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Close text
        canRunning = true;

        yield return new WaitForSeconds(1f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Door")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /*if (collision.gameObject.name == "Enemy")
        {
            startText.text = "Lmao That's wrong way\r\nCome on, follow me lol";
            startText.gameObject.SetActive(true);
            
        }*/
    }

}