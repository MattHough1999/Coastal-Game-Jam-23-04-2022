using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTrigger : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] float masterVol, bounceVol, toneMod = 1.50f;
    private AudioClip modClip;

    // Start is called before the first frame update
    void Start()
    {
        masterVol = PlayerPrefs.GetFloat("masterVol");
        bounceVol = PlayerPrefs.GetFloat("bounceVol") * masterVol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball" && !source.isPlaying) 
        {
            source.pitch = source.pitch + Random.Range(0.50f, toneMod);
            source.PlayOneShot(clip, bounceVol); 
        }
    }
}
