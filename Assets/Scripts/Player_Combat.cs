using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Player_Combat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int heavyAttack = 20;
    public int mediumAttack = 10;
    public int lightAttack = 5;
    public float attackRange = 0.5f;

    [SerializeField] GameObject hitBox;

    // Update is called once per frame
    void Update()
    {
        
    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hitBox.SetActive(true) ;
            Debug.Log("Status of hitbox  = true");
            HeavyAttack();
            hitBox.SetActive(false);
            Debug.Log("Status of hitbox = false" );
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            hitBox.SetActive(true);
            MediumAttack();
             hitBox.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            hitBox.SetActive(true);
            LightAttack();
             hitBox.SetActive(false);
        }
    }
    void HeavyAttack()
    {
        
    // play attack animation
        //animator.SetTrigger("HeavyAttack");
    // detect enemies in attack 
        Collider2D[]  hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy_Damage>().TakeDamage(heavyAttack);
        }
        // apply damage
    }
    void MediumAttack()
    {
        
    // play attack animation
        //animator.SetTrigger("MediumAttack");
        
    // detect enemies in attack 
        Collider2D[]  hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy_Damage>().TakeDamage(mediumAttack);
        }
        // apply damage
    }
    void LightAttack()
    {
        
    // play attack animation
        //animator.SetTrigger("lightAttack");
        
    // detect enemies in attack 
        Collider2D[]  hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy_Damage>().TakeDamage(lightAttack);
        }
        // apply damage
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
