using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHighscore : MonoBehaviour {

    public void SetHS(int kaas)
    {
        StreamWriter writer = new StreamWriter(@"C:assets\Highscores", true);
        Output = PlayerPrefs.GetFloat("Highscore").ToString();
        writer.WriteLine(Output);
        writer.Close();
    }
}
