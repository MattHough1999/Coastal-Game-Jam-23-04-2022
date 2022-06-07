using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] string loadScene, loadScene1, loadScene2;
    [SerializeField] float masterVol, musicVol, goalVol, bounceVol;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
        masterVol = PlayerPrefs.GetFloat("masterVol", 0.5f);
        musicVol = PlayerPrefs.GetFloat("musicVol", 0.5f * masterVol);
        goalVol = PlayerPrefs.GetFloat("goalVol", 0.5f * masterVol);
        bounceVol = PlayerPrefs.GetFloat("masterVol", 0.5f * masterVol);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying) 
        {
            audio.PlayOneShot(audio.clip, musicVol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            loadGame(loadScene);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            loadGame(loadScene2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            loadGame(loadScene1);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(SceneManager.GetActiveScene().name == "Menu") { quitGame(); }
            else { loadGame("Menu"); }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            quitGame();
        }
    }

    public void loadGame(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void quitGame() 
    {
        Application.Quit();
    }
    public void mute()
    {
        masterVol = 0;
        // musicVol = 0; goalVol = 0; bounceVol = 0 ;
    }
    
    
}
