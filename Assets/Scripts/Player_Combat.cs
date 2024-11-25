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
    private float pos;
    private UnityEngine.Vector3 Ppos, Npos;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int heavyAttack = 20;
    public int mediumAttack = 10;
    public int lightAttack = 5;
    public float attackRange = 0.5f;

    [SerializeField] GameObject hitBox;

    void Start()
    {
        pos = attackPoint.position.x;
        Ppos = new UnityEngine.Vector3(attackPoint.localPosition.x, attackPoint.localPosition.y, attackPoint.localPosition.z);
        Npos = new UnityEngine.Vector3(-attackPoint.localPosition.x, attackPoint.localPosition.y, attackPoint.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hitBox.SetActive(true);
            Attack(attackPoint, attackRange, heavyAttack);
            hitBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            hitBox.SetActive(true);
            Attack(attackPoint, attackRange, mediumAttack);
            hitBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hitBox.SetActive(true);
            Attack(attackPoint, attackRange, lightAttack);
            hitBox.SetActive(false);
        }

        //match attack point position to Octavia's direction
        if (attackPoint.parent.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x < 0)
        {
            attackPoint.localPosition = Npos;
        }
        if (attackPoint.parent.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x > 0)
        {
            attackPoint.localPosition = Ppos;
        }
    }

    void Attack(Transform pos, float range, int damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pos.position, range, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy_Damage>().TakeDamage(damage, (int)pos.localPosition.x);
        }
    }
    void AttackAnimation(/*whatever is needed to animate*/)
    {
        // add animation code
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}