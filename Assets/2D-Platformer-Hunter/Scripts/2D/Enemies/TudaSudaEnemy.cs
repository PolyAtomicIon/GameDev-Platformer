using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudaSudaEnemy : Enemy
{
    public override void Behave(){
        Vector3 curPosition = transform.position;
        curPosition.x = initialPos.x + Mathf.Cos(Time.time * _frequency.x) * _amplitude.x;

        // Debug.Log(curPosition);

        transform.position = curPosition;
    }

}
