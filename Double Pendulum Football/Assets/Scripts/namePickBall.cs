using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class namePickBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    public float timeout = 5.00f;
    float bounceVol, masterVol;

    public SpawnBall spawn;

    private float touchTimeout = 7.00f;
    int minForce, maxForce;
    ParticleSystem particles;
    Transform lookAt;
    // Start is called before the first frame update
    void Start()
    {
        masterVol = PlayerPrefs.GetFloat("masterVol");
        bounceVol = PlayerPrefs.GetFloat("bounceVol") * masterVol;
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
        touchTimeout = touchTimeout - Time.deltaTime;
        if (touchTimeout <= 0)
        {
            spawn.restart();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!source.isPlaying)
        {
            source.pitch = Random.Range(0.5f, 1.5f);
            source.PlayOneShot(clip, bounceVol);
        }

        touchTimeout = timeout;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "P2Goal2") 
        {
            if (particles != null)
            {
                particles.transform.position = collision.transform.position;
                particles.transform.LookAt(lookAt);
                particles.Play();
            }
            spawn.addLetter(collision.gameObject.name); 
        }
    }
}
