using System;
using UnityEngine;


public class Enemy_Damage : MonoBehaviour
    
{
    public Enemy_Movement enemyMovement;
    private Rigidbody2D playerRigidbody;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        enemyMovement = playerRigidbody.gameObject.GetComponent<Enemy_Movement>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(int damage, int direction)
    {
        currentHealth -= damage;
        //launches enemy up 
        playerRigidbody.AddForceY(direction * (damage) * (enemyMovement.JumpSpeed/40), ForceMode2D.Impulse);
        // pushes enemy back
        playerRigidbody.AddForceX(direction * (damage)*(enemyMovement.JumpSpeed/40), ForceMode2D.Impulse);
    
    // reduce health bar 
    
    }
}
