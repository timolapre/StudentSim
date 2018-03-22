﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

    private string StudyText = "Not managing your study enough can cause a lot of stress. All the side-activities of college life can take up so much time that spending time on the study itself becomes unattractive. Running behind on lectures and learning material can put students in a downward spiral, ending in them not being able to catch up and eventually dropping out. So, think about your future! Don’t forget why you are a student in the first place: To study!";
    private string SocialText = "Research finds that lonely students often are more viable to be unhappy, and in some cases they are more viable for depression. Student life offers a lot of possibilities to meet new people who are a lot like you. Don’t forget to get out there and meet some friends! A few beers in the pub with your mates once in a while can’t do a lot of harm! Also, don’t forget to see your parents once in a while!";
    private string SleepText = "Sleep is one of the most important primary needs. Without sleep, our senses become dulled and we ourselves become less immune to stress and diseases. Less sleep means our focus and concentration takes some hits as well. One of the primary causes of anxiety and depression among students is the amount of stress they experience. Make sure you get enough sleep, so that your body learns how to cope with all the pressures of student life!";
    private string FinishText = "Congratulations!!!";

    // Use this for initialization
    void Start () {
        GetComponent<Text>().text = GetText(Player.GameOverBecause);
	}

    string GetText(string i)
    {
        if (i == "study")
            return StudyText;
        if (i == "social")
            return SocialText;
        if (i == "sleep")
            return SleepText;
        if (i == "finish")
            return FinishText;
        return "ERROR, text not found";
    }
	
}
