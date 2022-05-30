using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    float volume = 0.5f;

    public SpawnBall spawn;
    
    private string lastTouched = "PlayerOne";
    private float touchTimeout = 7.00f;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("SpawnBall").GetComponent<SpawnBall>();
        rb.AddForce(Random.Range(-75, 75), Random.Range(-75, 75), 0, ForceMode.Impulse);
        Color color = new Color();
        color.r = Random.Range(0.00f, 1.00f);
        color.g = Random.Range(0.00f, 1.00f);
        color.b = Random.Range(0.00f, 1.00f);
        GetComponent<Renderer>().material.SetColor("_BaseColor", color);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -10.0f) 
        {
            outOfBounds(lastTouched);    
        }
        touchTimeout = touchTimeout - Time.deltaTime;
        if(touchTimeout <= 0) 
        {
            spawn.restart();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "PlayerOne" || collision.gameObject.tag == "PlayerTwo") { lastTouched = collision.gameObject.tag; }
        if (!source.isPlaying) 
        {
            source.pitch = Random.Range(0.5f, 1.5f);
            source.PlayOneShot(clip, volume);
        }
        
        touchTimeout = 7.00f;
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "P2Goal") { spawn.addPoint("PlayerOne", 1); }
        if (collision.gameObject.tag == "P1Goal") { spawn.addPoint("PlayerTwo", 1); }
        if (collision.gameObject.tag == "P2Goal2") { spawn.addPoint("PlayerOne", 5); }
        if (collision.gameObject.tag == "P1Goal2") { spawn.addPoint("PlayerTwo", 5); }
    }

    void outOfBounds(string lastTouched) 
    {
        if(lastTouched == "PlayerOne") 
        {
            spawn.addPoint("PlayerTwo", 1);
        }
        else 
        {
            spawn.addPoint("PlayerOne",1 );
        }
    }

    
    
}
