using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    [SerializeField] Transform origin, target;
    [SerializeField] float time, speed, distance;
    
    Transform swap;
    bool reachedPoint = true;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        swap = origin;
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedPoint) 
        {
            reachedPoint = false;
            swap = target;
            target = origin;
            origin = swap;
            speed = Random.Range(5, 20);
        }
        dist = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, dist);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            reachedPoint = true;
        }
    }
}
