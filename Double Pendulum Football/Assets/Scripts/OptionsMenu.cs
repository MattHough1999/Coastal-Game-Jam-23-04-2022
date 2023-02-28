using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    //[SerializeField] string loadScene, loadScene1, loadScene2;
    [SerializeField] float masterVol, musicVol, goalVol, bounceVol;
    [SerializeField] Slider master, music, goal, bounce;
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI saveText;
    [SerializeField] AudioSource source;
    [SerializeField] float mvol, muvol, gvol, bvol;
    // Start is called before the first frame update
    void Start()
    {
        getDefault();
        master.value = mvol;
        music.value = muvol;
        goal.value = gvol;
        bounce.value = bvol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            loadMenu();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            saveSettings();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        source.volume = musicVol;
        mvol = master.value;
        muvol = music.value;
        gvol = goal.value;
        bvol = bounce.value;
        
       if(mvol != PlayerPrefs.GetFloat("masterVol") || muvol != PlayerPrefs.GetFloat("musicVol") || gvol != PlayerPrefs.GetFloat("goalVol") || bvol != PlayerPrefs.GetFloat("bounceVol")) 
       {
            saveText.text = "Don't forget to save";
       } else { saveText.text = ""; }

        if (toggle.isOn) 
        {
            mute(true);
        }
        else { mute(false); }
            
    }

    public void getDefault() 
    {
        mvol = PlayerPrefs.GetFloat("masterVol",0.5f);
        muvol = PlayerPrefs.GetFloat("musicVol", 0.5f);
        gvol = PlayerPrefs.GetFloat("goalVol", 0.5f);
        bvol = PlayerPrefs.GetFloat("masterVol", 0.5f);
        
    }

    public void mute(bool flip)
    {
        if (flip)
        {
            mvol = 0;
            musicVol = 0;
        }
        else 
        { 
            mvol = master.value;
            musicVol = music.value * mvol;
        }
        // musicVol = 0; goalVol = 0; bounceVol = 0 ;
    }
    public void saveSettings()
    {
        PlayerPrefs.SetFloat("masterVol", mvol);
        PlayerPrefs.SetFloat("musicVol", muvol);
        PlayerPrefs.SetFloat("goalVol", gvol);
        PlayerPrefs.SetFloat("bounceVol", bvol);

        Debug.Log(mvol + " " + muvol + " " + gvol + " " + bvol);
        Debug.Log(PlayerPrefs.GetFloat("masterVol") + " " + PlayerPrefs.GetFloat("musicVol") + " " + PlayerPrefs.GetFloat("goalVol") + " " + PlayerPrefs.GetFloat("bounceVol"));

        getDefault();
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void resetStats() 
    {
        PlayerPrefs.DeleteAll();
        getDefault();

        master.value = mvol;
        music.value = muvol;
        goal.value = gvol;
        bounce.value = bvol;
    }
}
