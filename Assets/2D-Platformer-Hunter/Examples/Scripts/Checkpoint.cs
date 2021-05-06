using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject nonActivated;
    public GameObject activated;

    private bool isActivated = false;
    public void ActivateCheckpoint(){
        isActivated = true;
        changeSprite();
    }
    public bool IsActivated(){
        return isActivated;
    }

    public Vector3 GetPosition(){
        return transform.position;
    }

    public void changeSprite(){
        Debug.Log("change sprite");
        activated.SetActive(true);
        nonActivated.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        
        if (col.gameObject.tag == "Player")
        {
            ActivateCheckpoint();
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        Debug.Log(collision.gameObject.tag);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
