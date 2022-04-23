using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    public TextMeshProUGUI P1Score;
    public TextMeshProUGUI P2Score;
    public int player1Score = 0, player2Score = 0;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addPoint(string Player, int score)
    {
        if (Player == "PlayerOne")
        {
            player1Score = player1Score + score;
            P1Score.text = player1Score.ToString();
            restart();
        }
        if (Player == "PlayerTwo")
        {
            player2Score = player2Score + score;
            P2Score.text = player2Score.ToString();
            restart();
        }
    }
    public void restart()
    {
        Destroy(ball);
        
        ball = Instantiate(ballPrefab,gameObject.transform);
        ball.transform.SetParent(gameObject.transform);
        
        
    }
}
