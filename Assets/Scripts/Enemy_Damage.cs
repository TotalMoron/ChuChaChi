using System;
using UnityEngine;


public class Enemy_Damage : MonoBehaviour
    
{
    public Enemy_Movement enemyMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private Rigidbody2D enemyRigidbody;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Was able to access TakeDamage()");
        currentHealth -= damage;
        //launches enemy up 
        enemyRigidbody.AddForceY(5, ForceMode2D.Impulse);
        enemyRigidbody.AddForceX(5, ForceMode2D.Impulse);
       
        // pushes enemy back

    
    // reduce health bar 
    
    }
}
