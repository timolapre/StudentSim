using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetHighscores : MonoBehaviour {

    string Output;
    public void SetHS()
    {
        StreamWriter writer = new StreamWriter(@"C:assets\Highscores", true);
        Output = PlayerPrefs.GetFloat("Highscore").ToString();
        writer.WriteLine(Output);
        writer.Close();
    }
}
