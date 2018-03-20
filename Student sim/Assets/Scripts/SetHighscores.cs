using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetHighscores : MonoBehaviour {

    string Output;
    public GameObject can1, Highscores;
    public InputField Name;
    string Text;
    int Lines;
    private int i;

    private void Start()
    {
        Highscores.SetActive(false);
    }

    public void SetHS()
    {
        StreamWriter writer = new StreamWriter(@"C:assets\Highscores", true);
        Output = PlayerPrefs.GetFloat("Highscore").ToString() + ":" + Name.text;
        writer.WriteLine(Output);
        writer.Close();
        can1.SetActive(false);
        Highscores.SetActive(true);
    }

    public void ReadDB()
    {
        StreamReader Reader = new StreamReader(@"C:assets\Highscores", true);
        Lines = File.ReadAllLines(@"C:assets\Highscores").Length;
        do
        {
        }
        while (Text != null);
        Reader.Close();
    }
}
