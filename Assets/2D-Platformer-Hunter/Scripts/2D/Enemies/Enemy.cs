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

    public CombatInventory Weapon;

	public virtual void TakeDamage (float damage){
        Debug.Log("damge taken");

        Health -= damage;

        Debug.Log(damage);
        Destroy(gameObject);
    }

    public virtual void Behave(){
        Debug.Log("MOVES... will move..");
    }

    public bool isGrounded() {
        RaycastHit2D groundInfo = Physics2D.Raycast(transform.position, Vector2.down, 1);
        return groundInfo.collider;
    }

    public void Start() {
        // Weapon = GetComponent<CombatInventory>();
        if( Weapon )
            Weapon.Initialize();
        rb2D = GetComponent<Rigidbody2D>();
    }


    public void FixedUpdate () {
        Behave();
    }

}