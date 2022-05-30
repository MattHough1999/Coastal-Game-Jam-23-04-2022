using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Swing p1Swing;
    [SerializeField] Swing p2Swing;
    public TextMeshProUGUI P1Score;
    public TextMeshProUGUI P2Score;
    public AudioSource audioSource;
    public List<AudioClip> goalClips;
    public List<AudioClip> ownGoalClips;
    public float volume = 0.5f;

    public int player1Score = 0, player2Score = 0;
    GameObject ball;

    void Start()
        {
            ball = Instantiate(ballPrefab);
        }
    

    // Update is called once per frame
    void Update()
    {
        if(p1Swing.active == false && p2Swing.active == false) 
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void addPoint(string Player, int score,bool ownGoal)
    {
        if (Player == "PlayerOne")
        {
            if (ownGoal) audioSource.PlayOneShot(goalClips[Random.Range(0,goalClips.Count)], volume);
            else audioSource.PlayOneShot(ownGoalClips[Random.Range(0, ownGoalClips.Count)], volume);
            player1Score = player1Score + score;
            P1Score.text = player1Score.ToString();
            restart();
        }
        if (Player == "PlayerTwo")
        {
            if (ownGoal) audioSource.PlayOneShot(goalClips[Random.Range(0, goalClips.Count)], volume);
            else audioSource.PlayOneShot(ownGoalClips[Random.Range(0, ownGoalClips.Count)], volume);
            player2Score = player2Score + score;
            P2Score.text = player2Score.ToString();
            restart();
        }
        if(player1Score >= 15) 
        {
            PlayerPrefs.SetString("Winner", "Player 1");
            SceneManager.LoadScene("End");
        }
        else if (player2Score >= 15)
        {
            PlayerPrefs.SetString("Winner", "Player 2");
            SceneManager.LoadScene("End");
        }
    }
    public void restart()
    {
        Destroy(ball);
        
        ball = Instantiate(ballPrefab,gameObject.transform);
        ball.transform.SetParent(gameObject.transform);
        
        
    }
}
