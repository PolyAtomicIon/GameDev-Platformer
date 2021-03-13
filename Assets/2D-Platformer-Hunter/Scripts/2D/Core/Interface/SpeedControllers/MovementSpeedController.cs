using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using DYP;

public class MovementSpeedController : MonoBehaviour
{

    public Slider movementSlider;
    public BasicMovementController2D playerController;

    //Invoked when a submit button is clicked.
    public void ValueChangeCheck()
    {
        Debug.Log("Movement Slider value = " + movementSlider.value);
        Debug.Log("Movement speed value = " + playerController.MovementSpeed);
        playerController.MovementSpeed = movementSlider.value * 25;
    }

    // Start is called before the first frame update
    void Start()
    {
        movementSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
