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
