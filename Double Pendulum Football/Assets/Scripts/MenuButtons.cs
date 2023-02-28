using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    //[SerializeField] string loadScene, loadScene1, loadScene2;
    [SerializeField] float masterVol, musicVol, goalVol, bounceVol;
    [SerializeField] AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        masterVol = PlayerPrefs.GetFloat("masterVol", 0.5f);
        musicVol = PlayerPrefs.GetFloat("musicVol", 0.5f) * masterVol;
        goalVol = PlayerPrefs.GetFloat("goalVol", 0.5f) * masterVol;
        bounceVol = PlayerPrefs.GetFloat("bounceVol", 0.5f) * masterVol;
        source.volume = musicVol;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!source.isPlaying) 
        {
            source.PlayOneShot(source.clip, musicVol);
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if(SceneManager.GetActiveScene().name == "Menu") loadGame("SoloPlayer");
            else { loadGame("Menu"); }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(SceneManager.GetActiveScene().name == "Menu")loadGame("MultiPlayer");
            else { loadGame(PlayerPrefs.GetString("LastScene","Menu")); }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            loadGame("HighScores");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            loadGame("Options");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(SceneManager.GetActiveScene().name == "Menu") { quitGame(); }
            else { loadGame("Menu"); }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Application.Quit();
            //quitGame();
        }
    }

    public void loadGame(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    public void loadLast() 
    {
        loadGame(PlayerPrefs.GetString("LastScene","Menu"));
    }

    public void quitGame() 
    {
        Application.Quit();
    }
    public void mute()
    {
        masterVol = 0;
    }
    
    
}
