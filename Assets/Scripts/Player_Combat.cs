using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Player_Combat : MonoBehaviour
{
    public Enemy_Damage enemyDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   // public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int heavy_attack = 20;
    public int medium_attack = 10;
    public int light_attack = 5;
    public float attackRange = 0.5f;

    [SerializeField] GameObject hitBox;

 
    // Update is called once per frame
    void Update()
    {
        
        // Creates Heavy attack hitbox
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hitBox.SetActive(true) ;
            Debug.Log("Status of hitbox  = true");
            HeavyAttack();
            hitBox.SetActive(false);
            Debug.Log("Status of hitbox = false" );
        }
        // Creates Medium attack 
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            hitBox.SetActive(true);
            MediumAttack();
             hitBox.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            // Creates light attack 
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
            enemy.GetComponent<Enemy_Damage>().TakeDamage(heavy_attack);
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
            enemy.GetComponent<Enemy_Damage>().TakeDamage(medium_attack);
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
            enemy.GetComponent<Enemy_Damage>().TakeDamage(light_attack);
        }
        // apply damage
    }
    // creates visual of attack range
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
