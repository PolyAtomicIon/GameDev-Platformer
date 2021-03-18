using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Required when Using UI elements.
using TMPro;

public class Enemy : MonoBehaviour, IDamagable
{

    public Vector2 _amplitude = new Vector2(1, 1);
    public Vector2 _frequency = new Vector2(2.5f, 2.5f);

    // initial positin by X axis
    public Vector3 initialPos;

	public float Health { get; }    
    private TextMeshProUGUI HealthTextLabel;

	public void TakeDamage (float damage){
        Debug.Log("damge taken");

        // Health -= damage;
        // HealthTextLabel.text = Health.ToString();

        Debug.Log(damage);
        Destroy(gameObject);
    }

    public virtual void Behave(){
        Vector3 curPosition = transform.position;
        curPosition.x = initialPos.x + Mathf.Cos(Time.time * _frequency.x) * _amplitude.x;
        curPosition.y = initialPos.y + Mathf.Cos(Time.time * _frequency.y) * _amplitude.y;

        // Debug.Log(curPosition);

        transform.position = curPosition;
    }

    public void Start() {
        initialPos = transform.position;
    }

    public void Update () {
        Behave();
    }

}
