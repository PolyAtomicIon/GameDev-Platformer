using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostEnemyLocal : GhostEnemy
{ 
    void ActivateAI(){
        aiPath.canMove = true;
    }

    public void Start() {
        aiPath.canMove = false;
    }

    public void FixedUpdate () {
    }

    public void Update() {
        if( IsPlayerInFieldOfVision() ){
            ActivateAI();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}