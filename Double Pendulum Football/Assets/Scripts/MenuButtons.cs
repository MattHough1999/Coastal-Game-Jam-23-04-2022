using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] string loadScene;
    float timeOut = 3000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeOut = timeOut - Time.deltaTime;
        if (timeOut <= 0) quitGame();
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
