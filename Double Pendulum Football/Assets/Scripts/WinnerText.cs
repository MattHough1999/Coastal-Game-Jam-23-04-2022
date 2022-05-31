using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WinnerText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    
    // Start is called before the first frame update
    void Start()
    {
        winnerText.text = "FoolsBall! \n" + PlayerPrefs.GetString("Winner") + " wins!" ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
