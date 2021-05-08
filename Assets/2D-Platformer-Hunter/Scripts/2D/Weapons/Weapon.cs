using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform attackPos;
    public AudioSource attackSound;

    private Animator m_Animator;
    public string animationName;
    public GameObject shotVFX;

    public void Activate(){
        gameObject.SetActive(true);
    }

    public void Deactivate(){
        if(m_Animator)
            m_Animator.SetBool(animationName, false);
        gameObject.SetActive(false);
    }
    
    public void ResetTimer(){
        timeBtwShots = startTimeBtwShots;
    }

    public void TimerBetweenShots(){
        timeBtwShots -= Time.deltaTime;
    }

    public void PlayAudio(){
        if( attackSound )
            attackSound.Play();
    }


    public IEnumerator PlayVFX(){

        if( shotVFX )
            shotVFX.SetActive(true);

        yield return new WaitForSeconds(0.75f);

        if( shotVFX )
            shotVFX.SetActive(false);
    }

    
    public IEnumerator PlayAnimation(){
        m_Animator.SetBool(animationName, true);

        yield return new WaitForSeconds(0.225f);

        m_Animator.SetBool(animationName, false);
    }


    // ex: shoot a bullet, check for collisions
    public virtual void HandlePhysicsOfAttack(){
        Debug.Log("handling physics of attack:)");
    }

    public bool Attack()
    {
        if (timeBtwShots <= 0)
        {
            HandlePhysicsOfAttack();
            ResetTimer();
            PlayAudio();
            StartCoroutine(PlayVFX());
            StartCoroutine(PlayAnimation());
            // Ammo modification: decrease number of bullets -> RangedWeopon
            return true;
        }
        return false;
    }


    void Awake () {
        m_Animator = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator> ();
    }

    public void Start(){
        shotVFX.SetActive(false);
    }

    public void Update()
    {   
        TimerBetweenShots();
    }


 }