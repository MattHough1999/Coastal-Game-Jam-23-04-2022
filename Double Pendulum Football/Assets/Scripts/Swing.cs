using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swing : MonoBehaviour
{
    public bool active = true;

    [SerializeField] HingeJoint hinge;
    [SerializeField] HingeJoint secondaryHinge;
    [SerializeField] KeyCode swingLeft, swingRight, lockPendulum, lockPendulum1;
    [SerializeField] Slider boostSlider;
    [SerializeField] Image sliderFill;
    [SerializeField] float maxBoostTime = 5.00f, inactive;

    private float secHingeAngle = 0.00f;
    float boostTime;
    Color color = Color.red;
    GameObject hingeGo,secHingeGo;
    
    void Start()
    {
        boostTime = maxBoostTime;
        boostSlider.maxValue = maxBoostTime;
        if(hinge == null || secondaryHinge == null) 
        {
            Application.Quit();
        }
        hingeGo = hinge.gameObject;
        secHingeGo = secondaryHinge.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        var motor = hinge.motor;
        if (Input.GetKeyUp(swingRight) && Input.GetKeyUp(swingLeft) || !(Input.GetKey(swingRight) && Input.GetKey(swingRight)))
        {
            motor.force = 0;
            motor.targetVelocity = 0;
            motor.freeSpin = true;
        }

        if (Input.GetKey(swingRight)) 
        {
            motor.force = 2000;
            motor.targetVelocity = 140;
            motor.freeSpin = false;
            active = true;
            inactive = 0.00f;
            
        }
        if (Input.GetKey(swingLeft))
        {
            motor.force = 2000;
            motor.targetVelocity = -140;
            motor.freeSpin = false;
            active = true;
            inactive = 0.00f;

        }
        if (Input.GetKey(lockPendulum) || Input.GetKey(lockPendulum1))
        {
            if (boostTime >= 0)
            {
                motor.force = 5000;
                motor.targetVelocity = motor.targetVelocity * 3;
                boostTime = boostTime - (Time.deltaTime * 4);
            }
            
        }
        if(boostTime <= maxBoostTime) 
        {
            boostTime = boostTime + (Time.deltaTime * 2);
        }
        hinge.motor = motor;
        hinge.useMotor = true;
        boostSlider.value = boostTime;
        color.r = (boostTime * maxBoostTime) * (-1);
        color.g = boostTime / maxBoostTime;
        sliderFill.color = color;
        inactive = inactive + Time.deltaTime;
        if(inactive >= 120) 
        {
            active = false;
        }
    }
}
