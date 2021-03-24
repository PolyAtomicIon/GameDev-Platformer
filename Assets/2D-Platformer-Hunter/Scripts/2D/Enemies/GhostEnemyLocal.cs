using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostEnemyLocal : GhostEnemy
{ 

    public LayerMask HitableTargets;
    public float radius = 10;

    void ActivateAI(){
        aiPath.canMove = true;
    }

    void CheckForPlayer() {
        
        bool isFound = false;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radius, HitableTargets);
        for (int i = 0; i < targets.Length; i++)
        {
            // Debug.Log("SOMETHING found");
            
            if (targets[i].CompareTag("Player") ){
                // Debug.Log("player found");
                Weapon.Equip();
                isFound = true;
                ActivateAI();
            }
        }

        if( !isFound ){
            Weapon.Unequip();
        }
    }

    public void Start() {
        aiPath.canMove = false;
    }

    public void FixedUpdate () {
        Behave();
    }

    private void Update() {
        CheckForPlayer();

        if( aiPath.canMove ){
            if( Weapon ){
                Weapon.Attack();
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}