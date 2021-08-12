using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GETSCORE : MonoBehaviour
{
    public TextMeshProUGUI savedScore;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        savedScore.text = PlayerPrefs.GetInt("SavedScore").ToString();
        highScore.text = "HighScore    "+PlayerPrefs.GetInt("HighScore").ToString();
    }
}
