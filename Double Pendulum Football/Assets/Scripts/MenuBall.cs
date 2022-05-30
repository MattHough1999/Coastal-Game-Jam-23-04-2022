using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    // Start is called before the first frame update
    float dieTime = 10.00f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Random.Range(-75, 75), Random.Range(-75, 75), 0, ForceMode.Impulse);
        Color color = new Color();
        color.r = Random.Range(0.00f, 1.00f);
        color.g = Random.Range(0.00f, 1.00f);
        color.b = Random.Range(0.00f, 1.00f);
        //GetComponent<Renderer>().material.SetColor("_Color", color);
        GetComponent<Renderer>().material.SetColor("_BaseColor", color);
    }

    // Update is called once per frame
    void Update()
    {
        dieTime = dieTime - Time.deltaTime;
        if(dieTime <= 0) 
        {
            Destroy(gameObject);
            //GetComponent<Rigidbody>().AddForce(Random.Range(-75, 75), Random.Range(-75, 75), 0, ForceMode.Impulse);
        }
    }
}
