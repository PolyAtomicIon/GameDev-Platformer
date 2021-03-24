using System.Collections;
using UnityEngine;

[System.Serializable]
public class EnemyBowWeapon : RangedWeapon
{
    public Transform playerPosition;
    Vector3 positionError;

    // adds error to give the player a chance :)
    void setPositionError(){
        positionError = new Vector3( Random.Range(-0.5f, 0.5f),  Random.Range(-0.5f, 0.5f)  );
    }
    
    public override Vector3 GetPositionOfTarget(){
        setPositionError();
        Vector3 difference = playerPosition.position + positionError - transform.position;
        return difference;
    }

    private void Start() {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

}