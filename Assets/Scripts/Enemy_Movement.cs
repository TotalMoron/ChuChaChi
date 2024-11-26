using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float MovementSpeed, JumpSpeed;
    Animator animator;

    bool isGrounded, isJumpDelayed;
    int jumpCounter, jumpDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementDirection = Vector2.zero;
        //move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementDirection.x = -MovementSpeed;
            animator.SetFloat("Movement_State", movementDirection.x);
        }
        //move right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementDirection.x = MovementSpeed;
            animator.SetFloat("Movement_State", movementDirection.x);
        }
        //stops movement of player
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            movementDirection.x = 0;
            animator.SetFloat("Movement_State", 0);
        }
        /*start jump delay if on ground
         * stop moving on x plane
         */
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
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