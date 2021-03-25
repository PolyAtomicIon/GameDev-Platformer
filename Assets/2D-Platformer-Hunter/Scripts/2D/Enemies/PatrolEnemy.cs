using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{ 

    public float speed = 100f;
    public int direction = 1;
    public Transform groundDetection;
    public LayerMask EnvironmentLayer;

    private float height;

    public void ChangeDirection(){
        direction *= -1;
        if( direction == 1 )
            transform.eulerAngles = new Vector3( 0, 0, 0 );
        else if( direction == -1 )
            transform.eulerAngles = new Vector3( 0, -180, 0 );
    }

    bool IsGroundDetected(){        
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1);
        if( groundInfo.collider )
            return true;
        else
            return false;
    }

    bool IsWalldDetected(){
        Vector2 center = new Vector2(transform.position.x, transform.position.y);
        Vector2 topLeftCorner = new Vector2( center.x-radius, center.y+height/2.2f );
        Vector2 bottomRightCorner = new Vector2( center.x+radius, center.y-height/2.2f );

        if( direction == 1 ){
            topLeftCorner.x = center.x;
        } 
        else{ 
            bottomRightCorner.x = center.x;
        }

        Collider2D wallInfo = Physics2D.OverlapArea(topLeftCorner, bottomRightCorner, EnvironmentLayer);
        if( wallInfo )
            return true;
        else
            return false;
    }

    void CheckBorders(){
        if( !IsGrounded() )
            return;

        bool groundDetected = IsGroundDetected();
        bool wallDetected = IsWalldDetected();
        if( !groundDetected || wallDetected ){
            ChangeDirection();
        }
    }

    public void Start() {
        base.Start();
        height = transform.localScale.y;
    }

    public override void Behave(){
        float speedByXAxis = direction * Time.fixedDeltaTime * speed;
       
        // // if enemy attacks Hero
        // if( IsPlayerInFieldOfVision() ){
        //     speedByXAxis = 0;
        // }

        Vector3 newVelocity = new Vector3( speedByXAxis, rb2D.velocity.y, 0 );
        rb2D.velocity = newVelocity;
    }
    
    public void Update(){
        base.Update();
    }

    public void FixedUpdate() {
        base.FixedUpdate();
        CheckBorders();
    }
    
    public void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + new Vector3(radius*direction, 0, 0), new Vector3(radius, height, 1));
    }

}