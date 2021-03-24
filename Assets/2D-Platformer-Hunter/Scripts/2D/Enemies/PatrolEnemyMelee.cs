using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyMelee : Enemy
{ 

    public float speed = 100f;
    public int direction = 1;
    public float distance;


    public Transform groundDetection;

    public void changeDirection(){
        direction *= -1;
        if( direction == 1 )
            transform.eulerAngles = new Vector3( 0, 0, 0 );
        if( direction == -1 )
            transform.eulerAngles = new Vector3( 0, -180, 0 );
    }

    void checkForGround(){
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1);
        if( !groundInfo.collider ){
            changeDirection(); 
        }
    }

    void checkForOjectForward() {
        RaycastHit2D objectInfo = Physics2D.Raycast(groundDetection.position, Vector2.right * direction, 1);
        if( objectInfo.collider ){
            Debug.Log("object found");
            // changeDirection(); 
            if( objectInfo.collider.CompareTag("Player") ){
                Debug.Log("attack");
            }
            else{
                changeDirection();
            }
        }
    }

    public override void Behave(){
        Vector3 newVelocity = new Vector3( direction * Time.fixedDeltaTime * speed, rb2D.velocity.y, 0 );
        rb2D.velocity = newVelocity;
    }

    public void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate () {
        Behave();
    }

    private void Update() {

        if( isGrounded() ){ 
            checkForGround();
        }

        checkForOjectForward();
    }

}