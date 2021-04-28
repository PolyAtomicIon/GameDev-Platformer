using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DYP;

public class SpeedUpController : MonoBehaviour
{
    public BasicMovementController2D playerController;
    
    private bool isRunning = false;
    private float DefaultSpeed;
    private float RunSpeed;
    public float SpeedUpValue = 30;

    void Start()
    {
        DefaultSpeed = playerController.MovementSpeed;
        RunSpeed = DefaultSpeed + SpeedUpValue;
    }

    void Update()
    {
        // speedUpOnHoldingShift();
    }

    private void speedUpOnHoldingShift()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.Log("hello");
            isRunning = true;
            playerController.MovementSpeed = RunSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
            playerController.MovementSpeed = DefaultSpeed;
        }
    }
}