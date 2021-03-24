using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{ 

    public float speed = 100f;
    public int direction = 1;
    public float radius = 1;

    public Transform groundDetection;
    public LayerMask HitableTargets;

    private int isAttacking = 0;

    public void changeDirection(){
        direction *= -1;
        if( direction == 1 )
            transform.eulerAngles = new Vector3( 0, 0, 0 );
        if( direction == -1 )
            transform.eulerAngles = new Vector3( 0, -180, 0 );
    }

    void checkForGround(){
        if( !isGrounded() )
            return;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1);
        if( !groundInfo.collider ){
            changeDirection(); 
        }
    }

    void CheckForWall(){
        if( !isGrounded() )
            return;
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, Vector2.right*direction, 3);
        if( !wallInfo.collider ){
            changeDirection(); 
        }
    }

    void checkForDirectionOfPlayer(){
        // if( transform.position  )
    }

    void CheckForPlayer() {

        bool isFound = false;

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, 2*radius, HitableTargets);
        for (int i = 0; i < targets.Length; i++)
        {
            // Debug.Log("SOMETHING found");
            
            if (targets[i].CompareTag("Player") ){
                // Debug.Log("player found");

                checkForDirectionOfPlayer();

                Weapon.Equip();
                isFound = true;
                isAttacking = 1;
                break;
            }
            else{
                changeDirection();
            }
        }

        if( !isFound ){
            Weapon.Unequip();
            isAttacking = 0;
        }

    }

    public override void Behave(){
        Vector3 newVelocity = new Vector3( (isAttacking^1) * direction * Time.fixedDeltaTime * speed, rb2D.velocity.y, 0 );
        rb2D.velocity = newVelocity;
    }

    public void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate () {
        Behave();
    }

    private void Update() {

        checkForGround();

        bool isPlayerInZone = CheckForPlayer();
        if( isPlayerInZone ){
            if( Weapon ){
                Weapon.Attack();
            }
        }

        CheckForWall();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 2*radius);
    }

}