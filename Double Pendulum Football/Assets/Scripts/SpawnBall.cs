using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Swing p1Swing, p2Swing;
    [SerializeField] bool displayTime,count;
    public TextMeshProUGUI P1Score,P2Score,timeText;
    public AudioSource audioSource;
    public List<AudioClip> goalClips,ownGoalClips;
    public float volume = 0.5f, touchTimeout = 5.00f, matchTime = 120f;
    public int player1Score = 0, player2Score = 0, minForce = -75, maxForce = 75, reqGoals;

    GameObject ball;
    string nameString = "";
    
    

    void Start()
    {
        if (displayTime) { timeText.enabled = true; }
        else timeText.enabled = false;
        ball = Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (p2Swing == null)
        {
            timeText.text = "Score as many times as you can! Only " + (Mathf.Round(matchTime * 10) / 10) + " seconds left!";
        }
        if (!p1Swing.active)
        {
            if (p2Swing == null) 
            {
                //timeText.text = "Score as many times as you can! Only" + (Mathf.Round(matchTime * 10) / 10) + " seconds left!";
            }
            else if (!p2Swing.active) 
            {
                timeText.enabled = true;
                timeText.text = "<U>Someone do something!!!<U>\n" + (Mathf.Round(matchTime * 10) / 10) + " seconds until timeout";
                count = true;
                
            }
        }
        if(count) matchTime = matchTime - Time.deltaTime;
        if(matchTime <= 0) 
        {
            if(SceneManager.GetActiveScene().name == "SoloPlayer") 
            {
                PlayerPrefs.SetInt("LastScore", player1Score); loadNewScene("MakeName");
            }
            else
            {
                PlayerPrefs.SetInt("LastScore", player1Score); SceneManager.LoadScene("Menu");
            }
        }
    }

    public void addPoint(string Player, int score,bool ownGoal)
    {
        if (Player == "PlayerOne")
        {
            if (ownGoal) audioSource.PlayOneShot(goalClips[Random.Range(0,goalClips.Count)], volume);
            else audioSource.PlayOneShot(ownGoalClips[Random.Range(0, ownGoalClips.Count)], volume);
            player1Score = player1Score + score;
            P1Score.text = "Scored: " + player1Score.ToString();
            restart();
        }
        if (Player == "PlayerTwo")
        {
            if (ownGoal) audioSource.PlayOneShot(goalClips[Random.Range(0, goalClips.Count)], volume);
            else audioSource.PlayOneShot(ownGoalClips[Random.Range(0, ownGoalClips.Count)], volume);
            player2Score = player2Score + score;
            P2Score.text = "Scored: " + player2Score.ToString();
            restart();
        }
        if(player1Score >= reqGoals) 
        {
            PlayerPrefs.SetString("Winner", "Player 1");
            SceneManager.LoadScene("End");
        }
        else if (player2Score >= reqGoals)
        {
            PlayerPrefs.SetString("Winner", "Player 2");
            SceneManager.LoadScene("End");
        }
    }
    public void addLetter(string letter) 
    {
        if(nameString.Length <= 4) { nameString += letter; P1Score.text = "Your Name is: \n" + nameString; restart(); }
        else
        {

            PlayerPrefs.SetString("Scores", PlayerPrefs.GetString("Scores", "AAAAA10\nMATTH22") + "\n" + nameString + PlayerPrefs.GetInt("LastScore"));
            //PlayerPrefs.SetInt("totalHighScores", PlayerPrefs.GetInt("totalHighScores") + 1);
            SceneManager.LoadScene("HighScores");
        }
    }
    public void restart()
    {
        Destroy(ball);
        
        ball = Instantiate(ballPrefab,gameObject.transform);
        ball.transform.SetParent(gameObject.transform);
    }
    void loadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
