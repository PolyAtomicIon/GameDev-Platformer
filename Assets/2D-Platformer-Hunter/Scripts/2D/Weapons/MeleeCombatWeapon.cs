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
            Collider2D[] targets = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < targets.Length; i++)
            {
                Debug.Log("attack");
                IDamagable target = targets[i].GetComponent<IDamagable>();
                target.TakeDamage(damage);
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