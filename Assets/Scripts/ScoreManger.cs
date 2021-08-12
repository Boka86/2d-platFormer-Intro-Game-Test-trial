using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManger : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public int coinModifer;
    public TextMeshProUGUI scoreText;
    AudioSource source;
    public AudioClip coinSound;
    void Start()
    {
        score = 0;
        scoreText.text = " ";
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SaveHighScore();
        ShowScore();
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            AddScore();
            Destroy(collision.gameObject);
            IconCollectSound();
        }
       
        
            
        
    }

    void AddScore()
    {

        score += coinModifer;
        scoreText.text = " " + score;

    }

    void ShowScore()
    {
        scoreText.text = "" + score;
    }
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("SavedScore", score);

       
    }
    void IconCollectSound()
    {
      
        
            source.PlayOneShot(coinSound);
        
    }
}
