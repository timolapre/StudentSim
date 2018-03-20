using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetHighscores : MonoBehaviour {

    string Output;
    public GameObject can1, Highscores, TextField;
    private GameObject Field;
    public InputField Name;
    string Text;
    string[] Loaded;
    int Lines, j;

    private void Start()
    {
        Highscores.SetActive(false);
        j = 0;
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
        List<string> HSlist = new List<string>();
        StreamReader Reader = new StreamReader(@"C:assets\Highscores", true);
        do
        {
            Text = Reader.ReadLine();
            Loaded = Text.Split(':');
            Field = Instantiate(TextField, new Vector3(0,0,0), transform.rotation);
            Text TheText = Field.transform.GetComponent<Text>();
            TheText.text = Loaded[0] + "    " + Loaded[1];
            Field.transform.parent = Highscores.transform;
            Field.transform.position = new Vector3(300, 250 - 20 * j, 0);
            j++;
        }
        while (Text != null);
        Reader.Close();
    }
}
