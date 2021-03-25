using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostEnemy : Enemy
{ 

    public AIPath aiPath;
    public Transform gfx;

    public override void ChangeDirection(){
        if( !aiPath.canMove )
            return;

       if( aiPath.desiredVelocity.x >= 0.1f ){
            gfx.localScale = new Vector3(1f, 1f, 1f);
            direction = 1;
        }
        else if( aiPath.desiredVelocity.x <= -0.1f  ) {
            gfx.localScale = new Vector3(-1f, 1f, 1f);
            direction = -1;
        }
    }

    public override void Behave(){
        // Debug.Log("ghost enemy moves");
    }

    public void Awake() {
        aiPath = GetComponent<AIPath>();
    }

    private void Update() {
        base.Update();
        ChangeDirection();
    }

}