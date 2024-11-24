using System;
using UnityEngine;


public class Enemy_Damage : MonoBehaviour
    
{
    public Enemy_Movement enemyMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private Rigidbody2D playerRigidbody;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //launches enemy up 
        playerRigidbody.AddForceY(enemyMovement.JumpSpeed, ForceMode2D.Impulse);
        playerRigidbody.AddForceX(enemyMovement.JumpSpeed, ForceMode2D.Impulse);
        // pushes enemy back

    
    // reduce health bar 
    
    }
}
