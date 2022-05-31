using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] string loadScene;
    [SerializeField] string loadScene2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            loadGame(loadScene);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            loadGame(loadScene2);
        }
    }

    public void loadGame(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void quitGame() 
    {
        //Debug.Log("Quitting");
        Application.Quit();
    }
}
