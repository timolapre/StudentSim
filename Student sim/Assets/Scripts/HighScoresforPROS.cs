using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresforPROS : MonoBehaviour {

    float Score, CurrentScore;
    public Slider Sleep, Study, Social;
    public Text StudentScoreUI;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("Highscore", 60);
        InvokeRepeating("CalcSS", 1,20 );
    }
	
	// Update is called once per frame
	void Update () {
        CurrentScore = (Sleep.value + Study.value + Social.value) / 3;
        StudentScoreUI.text = "StudentScore:" + CurrentScore.ToString();
	}

    void CalcSS()
    {
        Score = (PlayerPrefs.GetFloat("Highscore") + CurrentScore) / 2;
        PlayerPrefs.SetFloat("Highscore", Score);
    }
}
