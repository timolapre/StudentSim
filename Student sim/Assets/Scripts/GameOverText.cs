using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour {

    private string StudyText = "Your Study is 0. pay more attention to learning. The danger is not finishing univeristy in 3 years.";
    private string SocialText = "Social life is important bruh. go out more often and PARTYYYY with your friends. or just chill with friends if you don't like to partehh";
    private string SleepText = "I know.. You're still young you don't need sleep blabla.. YOU DO! Sleep is important. if you don't sleep enough you will be tired (idk what happens)";

    // Use this for initialization
    void Start () {
        GetComponent<TextMeshProUGUI>().text = GetText(Player.GameOverBecause);
	}

    string GetText(string i)
    {
        if (i == "study")
            return StudyText;
        if (i == "social")
            return SocialText;
        if (i == "sleep")
            return SleepText;
        return "ERROR, text not found";
    }
	
}
