using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float MovementSpeed, JumpSpeed;

    bool isGrounded, isJumpDelayed;
    int jumpCounter, jumpDelay = 4;

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
        if (Input.GetKey("a"))
        {
            movementDirection.x = -MovementSpeed;
        }
        //move right
        else if (Input.GetKey("d"))
        {
            movementDirection.x = MovementSpeed;
        }
        //stops movement of player
        else if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            movementDirection.x = 0;
        }
        /*start jump delay if on ground
         * stop moving on x plane
         */
        if (Input.GetKey("w") && isGrounded)
        {
            isJumpDelayed = true;
        }
        //actually moves the player
        playerRigidbody.linearVelocity = (movementDirection);

        /*check if jump delay is on
         * delay for jumpDelay frames
         * jump player when delay is over.
         */
        if (isJumpDelayed == true)
        {
            if (jumpCounter > jumpDelay)
            {
                playerRigidbody.AddForceY(JumpSpeed, ForceMode2D.Impulse);
                isJumpDelayed = false;
                jumpCounter = 0;
            }
            movementDirection.x = 0;
            jumpCounter++;
        }
    }

    //Test if player is touching ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        //checks if on ground and stops sliding
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