using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    float MovementSpeed = 3;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDirection = Vector2.zero;
        if (Input.GetKey("a"))
        {
            movementDirection.x = -MovementSpeed;
        }
        else if (Input.GetKey("d"))
            {
                movementDirection.x = MovementSpeed;

            }
        else if (Input.GetKey("w") && isGrounded)
            {
                playerRigidbody.AddForceY(1,ForceMode2D.Impulse);
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
            playerRigidbody.angularVelocity = 0;
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