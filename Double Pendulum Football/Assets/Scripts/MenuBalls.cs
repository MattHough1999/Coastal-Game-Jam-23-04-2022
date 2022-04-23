using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    float addBall = 2.0f;
    void Start()
    {
        Transform trans = gameObject.transform;
        trans.position = new Vector3(trans.position.x - 6, trans.position.y, trans.position.z);
        Instantiate(ball,trans);
        trans.position = new Vector3(trans.position.x + 3, trans.position.y, trans.position.z);
        Instantiate(ball,trans);
        trans.position = new Vector3(trans.position.x + 3, trans.position.y, trans.position.z);
        Instantiate(ball,trans);
        trans.position = new Vector3(trans.position.x + 3, trans.position.y, trans.position.z);
        Instantiate(ball,trans);
        trans.position = new Vector3(trans.position.x + 3, trans.position.y, trans.position.z);
        Instantiate(ball,trans);
        trans.position = new Vector3(trans.position.x + 3, trans.position.y, trans.position.z);
        Instantiate(ball, trans);

    }

    // Update is called once per frame
    void Update()
    {
        addBall = addBall - Time.deltaTime;
        if(addBall <= 0) 
        {
            Instantiate(ball, transform);
            addBall = 1.5f;
        }
    }
}
