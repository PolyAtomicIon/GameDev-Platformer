using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class MeleeCombatWeapon : Weapon
{

    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage = 0;

    // Add combo attack

    public override void HandlePhysicsOfAttack(){
        Debug.Log("Melee attack");
        Collider2D[] targets = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < targets.Length; i++)
        {
            Debug.Log("attack");
            IDamagable target = targets[i].GetComponent<IDamagable>();
            target.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}