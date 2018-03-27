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
    public string[] Loaded;
    int Lines, j;

    private void Start()
    {
        Highscores.SetActive(false);
        j = 0;
    }

    public void SetHS()
    {
        if (Name.text != null)
        {
            StreamWriter writer = new StreamWriter(@"C:assets\Highscores", true);
            //StreamReader Reader = new StreamReader(@"C:assets\Highscores", true);
            Output = PlayerPrefs.GetFloat("Highscore").ToString() + ":" + Name.text;
            writer.WriteLine(Output);
            writer.Close();
            can1.SetActive(false);
            Highscores.SetActive(true);
            //Reader.Close();
        }
    }

    public void ReadDB()
    {
        StreamReader Reader = new StreamReader(@"C:assets\Highscores", true);
        do
        {
            Text = Reader.ReadLine();
            try
            {
                Loaded = Text.Split(':');
            }
            catch { }
            Field = Instantiate(TextField, new Vector3(0,0,0), transform.rotation);
            Text TheText = Field.transform.GetComponent<Text>();
            TheText.text = Loaded[0] + "    " + Loaded[1];
            Field.transform.parent = Highscores.transform;
            Field.transform.localScale = new Vector3(1, 1, 1);
            Field.transform.localPosition = new Vector3(0, 100 - 23 * j, 0);
            j++;
        }
        while (Text != null);
        Reader.Close();
    }
}
