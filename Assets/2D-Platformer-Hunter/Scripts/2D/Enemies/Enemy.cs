using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Required when Using UI elements.
using TMPro;

[RequireComponent(typeof(CombatInventory))]
public class Enemy : MonoBehaviour, IDamagable
{ 
	public float Health { get; set; }    

    [HideInInspector]
    public Rigidbody2D rb2D;
    public float radius = 1;
    public GameObject player;
    public CombatInventory Weapon;
    public LayerMask HitableTargets;

    public bool IsPlayerInFieldOfVision() {
        if( player )
            return true;
        return false;
    }

    public void AttackIfPlayerDetected(){
        if( !IsPlayerInFieldOfVision() )
            return;

        if( Weapon ){
            Weapon.Attack();
        }
        // Activate SOUND
        // Activate VFX
        // Activate Animation
    }

	public virtual void TakeDamage (float damage){
        Debug.Log("damge taken");

        Health -= damage;

        Debug.Log(damage);
        Destroy(gameObject);
    }

    public bool IsGrounded() {
        RaycastHit2D groundInfo = Physics2D.Raycast(transform.position, Vector2.down, 1);
        return groundInfo.collider;
    }

    public void SearchPlayer() {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, 2*radius, HitableTargets);
        for (int i = 0; i < targets.Length; i++){
            if (targets[i].CompareTag("Player") ){
                player = targets[i].gameObject;
                return;
            }
        }

        player = null;
    }

    public void Start() {
        if( Weapon )
            Weapon.Initialize();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public virtual void Behave(){
        Debug.Log("MOVES... will move..");
    }

    public void Update(){
        AttackIfPlayerDetected();
    }

    public void FixedUpdate () {
        SearchPlayer();
        Behave();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 2*radius);
    }

}