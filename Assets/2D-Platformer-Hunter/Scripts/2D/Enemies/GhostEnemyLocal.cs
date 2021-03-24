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
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radius, HitableTargets);
        for (int i = 0; i < targets.Length; i++)
        {
            // Debug.Log("SOMETHING found");
            
            if (targets[i].CompareTag("Player") ){
                // Debug.Log("player found");
                ActivateAI();
            }
        }
    }

    // void checkForPlayer() {
    //     RaycastHit2D objectInfoForwards = Physics2D.Raycast(transform.position, Vector2.right * direction, distance);
    //     RaycastHit2D objectInfoBackwards = Physics2D.Raycast(transform.position, Vector2.left * direction, distance);

    //     if( objectInfoForwards.collider ){

    //         pointForward = objectInfoForwards.point;

    //         if( objectInfoForwards.collider.CompareTag("Player") ){
    //             Debug.Log("player found");
    //             ActivateAI();
    //         }
    //     }
    //     else if( objectInfoBackwards.collider  ){

    //         pointBackward = objectInfoBackwards.point;

    //         if( objectInfoBackwards.collider.CompareTag("Player")  ){
    //             Debug.Log("player found");
    //             ActivateAI();
    //         }
    //     }
    // }

    public override void Behave(){
        // Debug.Log("ghost enemy moves");
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