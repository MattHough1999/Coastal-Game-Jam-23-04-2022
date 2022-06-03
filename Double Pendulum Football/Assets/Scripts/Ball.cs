using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform lookAt;
    public float volume = 0.5f,timeout = 5.00f;

    public SpawnBall spawn;

    private string lastTouched;
    private float touchTimeout = 7.00f;
    int minForce, maxForce;
   
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("SpawnBall").GetComponent<SpawnBall>();
        lookAt = GameObject.Find("LookAt").transform;
        particles = spawn.PS;
        minForce = spawn.minForce; maxForce = spawn.maxForce;
        rb.AddForce(Random.Range(minForce, maxForce), Random.Range(-75, 75), 0, ForceMode.Impulse);
        Color color = new Color();
        color.r = Random.Range(0.00f, 1.00f);
        color.g = Random.Range(0.00f, 1.00f);
        color.b = Random.Range(0.00f, 1.00f);
        GetComponent<Renderer>().material.SetColor("_BaseColor", color);
        timeout = spawn.touchTimeout;
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
        
        touchTimeout = timeout;
    }
    private void OnTriggerEnter(Collider collision)
    {
        string col = collision.gameObject.tag;
        switch (col)
        {
            case "P2Goal":
                if(lastTouched == "PlayerTwo") { spawn.addPoint("PlayerOne", 1, false); }
                else { spawn.addPoint("PlayerOne", 1, true); }
                    break;
            case "P2Goal2":
                if (lastTouched == "PlayerTwo") { spawn.addPoint("PlayerOne", 5, false); }
                else { spawn.addPoint("PlayerOne", 5, true); }
                break;
            case "P1Goal":
                if (lastTouched == "PlayerOne") { spawn.addPoint("PlayerTwo", 1, false); }
                else { spawn.addPoint("PlayerTwo", 1, true); }
                break;
            case "P1Goal2":
                if (lastTouched == "PlayerOne") { spawn.addPoint("PlayerTwo", 5, false); }
                else { spawn.addPoint("PlayerTwo", 5, true); }
                break;

            default: break;

        }
        if (particles != null)
        {
            particles.transform.position = collision.transform.position;
            particles.transform.LookAt(lookAt);
            particles.Play();
        }


    }

    void outOfBounds(string lastTouched) 
    {
        if(lastTouched == "PlayerOne") 
        {
            spawn.addPoint("PlayerTwo", 1, true);
        }
        else 
        {
            spawn.addPoint("PlayerOne", 1, true);
        }
    }

    
    
}
