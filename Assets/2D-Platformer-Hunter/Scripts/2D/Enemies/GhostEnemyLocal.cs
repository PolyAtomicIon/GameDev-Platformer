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
        base.Start();
        aiPath.canMove = false;
    }

    public void Update() {
        base.Update();
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