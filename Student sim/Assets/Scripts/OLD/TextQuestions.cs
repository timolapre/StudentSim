using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextQuestions : MonoBehaviour {

    public int id;

    public Text Question, Answer1, Answer2;
    public Questions[] questions;

    // Use this for initialization
    void Start () {
        id = Random.Range(1, questions.Length + 1);

    }
	
	// Update is called once per frame
	void Update () {
        Question.text = questions[id - 1].Question;
        Answer1.text = questions[id - 1].Answer1;
        Answer2.text = questions[id - 1].Answer2;
    }

    [System.Serializable]
    public struct Questions
    {
        public string Question;
        public string Answer1;
        public string Answer2;
        public int[] Changes;
    }
}
