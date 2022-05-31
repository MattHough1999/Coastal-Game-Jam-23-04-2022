using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Highscores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    string[] scoreNames; //= new string[PlayerPrefs.GetInt("totalHighScores")]; 
    string[,] highscores = new string[10, 2];
    int[] scores; // = new int[PlayerPrefs.GetInt("totalHighScores")];
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        initiateArray();
        
        scoreNames = PlayerPrefs.GetString("Scores","AAAAA10\nMATTH22").Split();
        scores = new int[scoreNames.Length];
        //split into names and score
        for (int i = 0; i < scoreNames.Length; i++) 
        {
            scores[i] = Int32.Parse(scoreNames[i].Substring(5));
            scoreNames[i] = scoreNames[i].Substring(0,5); 
        }

        //sort arrays
        int temp = 0;
        string tempS = "";

        for (int i = 0; i <= scores.Length - 1; i++)
        {
            for (int j = i + 1; j < scores.Length; j++)
            {
                if (scores[i] < scores[j])
                {
                    temp = scores[i];
                    tempS = scoreNames[i];
                    scores[i] = scores[j];
                    scoreNames[i] = scoreNames[j];
                    scores[j] = temp;
                    scoreNames[j] = tempS;
                }
            }
        }

        //create table
        for(int i = 0;i < scoreNames.Length; i++) 
        {
            highscores[i, 0] = scoreNames[i];
            highscores[i, 1] = scores[i].ToString();
        }

        drawText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void initiateArray()
    {
        for (int i = 0; i < highscores.Length/2; i++) 
        {
            highscores[i, 0] = "AAAAA";
            highscores[i, 1] = "0";
        }
    }
    void drawText() 
    {
        for(int i = 0; i < highscores.Length / 2; i++) 
        {
            winnerText.text = winnerText.text + highscores[i, 0] + "<B>" +": " + highscores[i, 1] + "</B>" + "\n"; 
        }
    }
}
