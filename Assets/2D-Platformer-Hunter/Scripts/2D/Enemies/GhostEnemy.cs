using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostEnemy : Enemy
{ 

    private AIPath aiPath;
    public Transform gfx;

    public void changeDirection(){
       if( aiPath.desiredVelocity.x >= 0.1f ){
            gfx.localScale = new Vector3(1f, 1f, 1f);
        }
        else if( aiPath.desiredVelocity.x <= -0.1f  ) {
            gfx.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public override void Behave(){
        Debug.Log("ghost enemy moves");
    }

    public void Start() {
        aiPath = GetComponent<AIPath>();
    }

    public void FixedUpdate () {
        Behave();
    }

    private void Update() {
        changeDirection();
    }

}