using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{

	public float Health { get; }
	public void TakeDamage (float damage){
        Debug.Log("damge taken");
        Debug.Log(damage);
        Destroy(gameObject);
    }
}
