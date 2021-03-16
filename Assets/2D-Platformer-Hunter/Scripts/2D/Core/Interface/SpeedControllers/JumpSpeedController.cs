using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using DYP;

public class JumpSpeedController : MonoBehaviour
{
    public Slider jumpSlider;
    public BasicMovementController2D playerController;

    //Invoked when a submit button is clicked.
    public void ValueChangeCheck()
    {
        Debug.Log("JumpSlider value = " + jumpSlider.value);
        Debug.Log("Jump speed value = " + playerController.MaxJumpSpeed);
        playerController.MaxJumpSpeed = jumpSlider.value * 50;
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

