using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextforPROS : MonoBehaviour {

    int Score , Years, Months, Weeks, Days;
    
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = Getprogress();
    }
	
    public string Getprogress()
    {
        Score = PlayerPrefs.GetInt("Score");
        Years = Score / (28 * 12);
        Months = (Score - Years * (28 * 12)) / 28;
        Weeks = (Score - Months * 28 - Years * (28 * 12)) / 7;
        Days = Score - Weeks * 7 - Months * 28 - Years * (28 * 12);
        return "Lasted: " + Years.ToString() + " Years " + Months.ToString() + " Months " + Weeks.ToString() + " Weeks " + Days.ToString() + " Days ";
    }
}
