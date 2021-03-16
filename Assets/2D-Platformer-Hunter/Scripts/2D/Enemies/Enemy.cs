using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{

    [SerializeField]
    private int _amplitude = 1;
    [SerializeField]
    private float _frequency = 2.5f;

    // initial positin by X axis
    private float xPos;

	public float Health { get; }
	public void TakeDamage (float damage){
        Debug.Log("damge taken");
        Debug.Log(damage);
        Destroy(gameObject);
    }

    void Start() {
        xPos = transform.position.x;
    }

    void Update () {

        Vector3 curPosition = transform.position;
        curPosition.x = xPos + Mathf.Cos(Time.time * _frequency) * _amplitude;

        // Debug.Log(curPosition);

        transform.position = curPosition;
    }

}
