using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using DYP;
using TMPro;

public class MovementSpeedController : MonoBehaviour
{

    public Slider movementSlider;
    public TextMeshProUGUI Value_TextLabel;
    public BasicMovementController2D playerController;

    //Invoked when a submit button is clicked.
    public void ValueChangeCheck()
    {
        Debug.Log("Movement Slider value = " + movementSlider.value);
        Debug.Log("Movement speed value = " + playerController.MovementSpeed);
        float finalValue = movementSlider.value * 25;
        playerController.MovementSpeed = finalValue;
        Value_TextLabel.text = finalValue.ToString();
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
