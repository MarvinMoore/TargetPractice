using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private float score;
    public AudioSource audioData;


    // Update is called once per frame
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
        }
    }
    public void changeScore(int coinValue)
    {
        audioData.Play();
        score += coinValue;
        GlobalAchievement.ach01Count += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
