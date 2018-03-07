using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour {

    public int id;

    public static int TimeHighScore, FinishHighscore;
    public static List<int> ListHighscore = new List<int>{0,0,0,0,0,0,0,0,0,0};

    TextMeshProUGUI text;

    void Start()
    {
        try
        {
            text = GetComponent<TextMeshProUGUI>();
            if(id == 1)
                text.text = ListHighscore[0] + "\n" + ListHighscore[1] + "\n" + ListHighscore[2] + "\n" + ListHighscore[3] + "\n" + ListHighscore[4];
            else if (id == 2)
                text.text = ListHighscore[5] + "\n" + ListHighscore[6] + "\n" + ListHighscore[7] + "\n" + ListHighscore[8] + "\n" + ListHighscore[9];
        }
        catch { }
    }

    static public void HighScoreCheck(int score, int id, float study, float social, float sleep)
    {
        for (int i = 0; i < 10; i++)
        {
            if (id == 1 && score > ListHighscore[i])
            {
                ListHighscore.Insert(i,score);
                //ListHighscore.RemoveAt(10);
                Debug.Log("New Highscore at" + i + "of" + score);
                return;
            }
            if (id == 2 && (int)(study + social + sleep) / 5 + score > ListHighscore[i])
            {
                ListHighscore.Insert(i, (int)(study + social + sleep) / 5 + score);
                //ListHighscore.RemoveAt(10);
                Debug.Log("New COMPLETE Highscore at " + i + " of ");
                Debug.Log((int)(study + social + sleep) / 5 + score);
                return;
            }
        }
    }
}
