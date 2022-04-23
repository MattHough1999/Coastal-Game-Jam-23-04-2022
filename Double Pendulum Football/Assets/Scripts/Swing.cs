using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HingeJoint hinge;
    [SerializeField] KeyCode swingLeft;
    [SerializeField] KeyCode swingRight;
    
    void Start()
    {
        if(hinge == null) 
        {

            Application.Quit();
        }
        
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
            //motor = hinge.motor;
            motor.force = 1000;
            motor.targetVelocity = 90;
            motor.freeSpin = false;
            
        }
        if (Input.GetKey(swingLeft))
        {
            //motor = hinge.motor;
            motor.force = 1000;
            motor.targetVelocity = -90;
            motor.freeSpin = false;
            //hinge.motor = motor;
            //hinge.useMotor = true;
        }
        
        hinge.motor = motor;
        hinge.useMotor = true;
    }
}
