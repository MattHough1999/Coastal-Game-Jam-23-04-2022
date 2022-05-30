using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] string loadScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            loadGame();
        }
        
    }

    public void loadGame() 
    {
        SceneManager.LoadScene(loadScene);
    }
    public void quitGame() 
    {
        //Debug.Log("Quitting");
        Application.Quit();
    }
}
