using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HingeJoint hinge;
    [SerializeField] HingeJoint secondaryHinge;
    [SerializeField] KeyCode swingLeft;
    [SerializeField] KeyCode swingRight;
    [SerializeField] KeyCode lockPendulum;
    [SerializeField] Slider boostSlider;
    [SerializeField] Image sliderFill;


    private float secHingeAngle = 0.00f,boostTime = 5.00f;
    Color color = Color.red;
    GameObject hingeGo,secHingeGo;
    
    void Start()
    {
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
            
        }
        if (Input.GetKey(swingLeft))
        {
            motor.force = 2000;
            motor.targetVelocity = -140;
            motor.freeSpin = false;
            
        }
        if (Input.GetKey(lockPendulum))
        {
            if (boostTime >= 0)
            {
                motor.force = 5000;
                motor.targetVelocity = motor.targetVelocity * 3;
                boostTime = boostTime - (Time.deltaTime * 4);
            }
            
        }
        if(boostTime <= 5) 
        {
            boostTime = boostTime + Time.deltaTime;
        }
        hinge.motor = motor;
        hinge.useMotor = true;
        boostSlider.value = boostTime;
        //color.r = (boostTime / 5) * (-1);
        color.g = boostTime / 5;
        sliderFill.color = color;
    }
}
