using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public Text scoreCounter;
    static public int score = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("scoreCounter"))
        {
            score = PlayerPrefs.GetInt("ScoreCounter");
        }
        PlayerPrefs.SetInt("ScoreCounter", score);
    }

}
