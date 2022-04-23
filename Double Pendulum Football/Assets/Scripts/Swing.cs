using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HingeJoint hinge;
    [SerializeField] HingeJoint secondaryHinge;
    [SerializeField] KeyCode swingLeft;
    [SerializeField] KeyCode swingRight;
    [SerializeField] KeyCode lockPendulum;
    private float secHingeAngle = 0.00f;
    
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
        var limits = secondaryHinge.limits;
        if (Input.GetKeyUp(swingRight) && Input.GetKeyUp(swingLeft) || !(Input.GetKey(swingRight) && Input.GetKey(swingRight)))
        {
            motor.force = 0;
            motor.targetVelocity = 0;
            motor.freeSpin = true;
        }
        secondaryHinge.limits = limits;
        secondaryHinge.useLimits = true;
        if (!Input.GetKey(lockPendulum)) 
        {
            limits.min = 0;
            limits.max = 0;
            secondaryHinge.limits = limits;
            secondaryHinge.useLimits = false;
        }

        if (Input.GetKey(swingRight)) 
        {
            motor.force = 1000;
            motor.targetVelocity = 140;
            motor.freeSpin = false;
            
        }
        if (Input.GetKey(swingLeft))
        {
            motor.force = 1000;
            motor.targetVelocity = -140;
            motor.freeSpin = false;
            
        }
        if (Input.GetKey(lockPendulum))
        {
            //secondaryHinge.useLimits = true;
            limits = secondaryHinge.limits;
            secHingeAngle = secondaryHinge.angle;
            limits.min = secHingeAngle - 1;
            limits.max = secHingeAngle + 1;
            
            Debug.Log("Locked " + lockPendulum.ToString());
            Debug.Log(secHingeAngle);
        }
        //secondaryHinge.limits = limits;
        
        hinge.motor = motor;
        hinge.useMotor = true;
        
    }
}
