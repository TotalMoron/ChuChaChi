using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy_Movement : MonoBehaviour
{
 private Rigidbody2D playerRigidbody;
    public float MovementSpeed = 8, JumpSpeed = 70;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         //move left
        Vector2 movementDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementDirection.x = -MovementSpeed;
        }
        // move right
        else if (Input.GetKey(KeyCode.RightArrow))
            {
                movementDirection.x = MovementSpeed;

            }
        // hump
         else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            movementDirection.x = 0;
        }
        //actually moves the player
        playerRigidbody.linearVelocity = (movementDirection);
        /*jump if on ground
         * stop moving on x plane
         */
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                playerRigidbody.AddForceY(JumpSpeed,ForceMode2D.Impulse);
                movementDirection.x = 0;
            }
        playerRigidbody.AddForce((movementDirection), ForceMode2D.Force);
    }
    //Test if player is touching ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            playerRigidbody.linearVelocityX = 0;
        }

    }
    //sets grounded to false if player are not on gorund
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
