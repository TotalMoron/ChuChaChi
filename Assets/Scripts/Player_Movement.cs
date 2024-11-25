using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float MovementSpeed, JumpSpeed;
    Animator animator;
    float MovementSpeed = 8, JumpSpeed = 70;

    bool isGrounded, isJumpDelayed;
    int jumpCounter, jumpDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirection = Vector2.zero;
        //move left
        if (Input.GetKey("a"))
        {
            movementDirection.x = -MovementSpeed;
            animator.SetFloat("Movement_State",movementDirection.x);        
        }
        //move right
        else if (Input.GetKey("d"))
        {
            movementDirection.x = MovementSpeed;
            animator.SetFloat("Movement_State",movementDirection.x);
        }
        //stops movement of player
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            movementDirection.x = 0;
            animator.SetFloat("Movement_State",0);
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
        if (isJumpDelayed == true && isGrounded == true)
        {
            jumpCounter++;
            if (jumpCounter > jumpDelay)
            {
                playerRigidbody.AddForceY(JumpSpeed, ForceMode2D.Impulse);
                isJumpDelayed = false;
                jumpCounter = 0;
            }
            //playerRigidbody.AddForceY(JumpSpeed, ForceMode2D.Impulse);
            playerRigidbody.linearVelocityY = JumpSpeed;
            movementDirection.x = 0;
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