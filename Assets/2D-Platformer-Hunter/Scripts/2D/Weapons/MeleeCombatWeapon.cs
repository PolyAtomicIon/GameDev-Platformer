using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class MeleeCombatWeapon : Weapon
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public override void Attack()
    {
        if (timeBtwShots <= 0)
        {
            Debug.Log("Melee attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                Debug.Log("attack");
                Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
                if (enemy)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

            }
        }
    }

    private void Update()
    {
        timeBtwShots -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}