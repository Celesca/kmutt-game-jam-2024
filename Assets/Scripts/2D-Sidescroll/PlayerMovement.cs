using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    [SerializeField] private float rollingSpeed;

    private Rigidbody2D body;
    private Animator anim;
    private bool canHide;
    private bool isHiding;
    private bool canRoll;
    private bool isRolling;

    private void Awake()
    {
        // Grabs references for rigidbody and animator from the game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Flip player when facing left/right.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Check if not hiding and not rolling
        if (!isHiding && !isRolling)
        {
            body.velocity = new Vector2(horizontalInput * normalSpeed, body.velocity.y);

            if (horizontalInput > 0.01f)
                transform.localScale = Vector3.one;
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);

            anim.SetBool("Run", horizontalInput != 0);
        }

        // Check if hiding, can roll, and horizontal input is not zero
        else if ((isHiding || isRolling) && canRoll && horizontalInput != 0)
        {
            body.velocity = new Vector2(horizontalInput * rollingSpeed, body.velocity.y);
        }

        // Check if hiding and DownArrow is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (canRoll && !isRolling)
            {
                Roll();
            }

            if (canHide && !isHiding)
            {
                Hide();
            }
            else if (isHiding)
            {
                // Release hiding when DownArrow is released
                if (!Input.GetKey(KeyCode.DownArrow))
                {
                    ReleaseHide();
                }
            }
        }
        else if (isHiding)
        {
            // Release hiding when DownArrow is not pressed
            ReleaseHide();
        }

        // Check if rolling and not in the RollingSpot
        if (isRolling && !canRoll)
        {
            anim.SetBool("hide", false); // Return to idle animation
            isRolling = false;
        }
    }

    private void Hide()
    {
        anim.SetBool("hide", true);
        isHiding = true;
        isRolling = false; // Ensure isRolling is false when hiding
        body.velocity = Vector2.zero; // Stop movement when hiding
    }

    private void Roll()
    {
        anim.SetBool("hide", true); // Use the same hiding animation
        isRolling = true;
    }

    private void ReleaseHide()
    {
        anim.SetBool("hide", false);
        isHiding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HidingSpot"))
        {
            canHide = true;
        }

        if (collision.gameObject.CompareTag("RollingSpot"))
        {
            canRoll = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HidingSpot"))
        {
            canHide = false;
            ReleaseHide(); // Release hiding when leaving hiding spot
        }

        if (collision.gameObject.CompareTag("RollingSpot"))
        {
            canRoll = false;
            if (isRolling)
            {
                anim.SetBool("hide", false); // Return to idle animation
                isRolling = false;
            }
        }
    }
}