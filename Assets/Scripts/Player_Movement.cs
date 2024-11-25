using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    Animator animator;
    float MovementSpeed = 8, JumpSpeed = 100;

    bool isGrounded;

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
        else if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            movementDirection.x = 0;
            animator.SetFloat("Movement_State",0);
        }
        //actually moves the player
        playerRigidbody.linearVelocity = (movementDirection);

        /*jump if on ground
         * stop moving on x plane
         */
        if (Input.GetKey("w") && isGrounded)
        {
            playerRigidbody.AddForceY(JumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("IsJumping",true);
            //playerRigidbody.linearVelocityY = JumpSpeed;
            movementDirection.x = 0;
            
            
        }
    }
    //Test if player is touching ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        //checks if on ground and stops sliding
        if (other.gameObject.CompareTag("Floor"))
        {
            animator.SetFloat("Movement_state",0);
            animator.SetBool("IsJumping",false);
            animator.SetFloat("yVelocity",1);
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