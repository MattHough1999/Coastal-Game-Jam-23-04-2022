using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {

        rb.AddForce(Random.Range(-75, 75), Random.Range(-75, 75), 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z <= -10.0f) 
        {
            
        }
    }


}
