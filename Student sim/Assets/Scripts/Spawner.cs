using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{

    public static int QuestionPosZ = 1000;

    public int Multiplier = 5, RenderDistance = 10, QuestionAfter = 20, ShowQuestionAfterDistance = 5;

    public GameObject[] Obstacle;
    public GameObject Floor, Hedge, QuestionObject;
    public Player player;

    public static int FloorSpawnID, SpawnAction;
    private int QuestionCount, RandomObj;
    public static bool Question;
    private Vector3 QuestionPos;
    private bool SpawnLevel = true;

    GameObject Rotater;

    public int WhatQuestion = 0;
    public Canvas QuestionCanvas;
    public TextMeshProUGUI QuestionText, Answer1Text, Answer2Text;
    public Questions[] questions;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("SpawnObject", 0, 1f);
        //InvokeRepeating("SpawnQuestion", 0, 10);
        Rotater = player.transform.Find("Rotater").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, transform.position.z);

        if (SpawnAction == 0 && player.transform.position.z > FloorSpawnID * Multiplier - Multiplier * RenderDistance && !Question)
        {
            QuestionCount++; ;
            Instantiate(Floor, player.transform.forward * (FloorSpawnID * Multiplier), transform.rotation);
            //Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * 10), transform.rotation);
            Instantiate(Hedge, new Vector3(3, 2, FloorSpawnID * Multiplier), transform.rotation);
            Instantiate(Hedge, new Vector3(-3, 2, FloorSpawnID * Multiplier), transform.rotation);
            if (FloorSpawnID > 5)
                SpawnObject();
            FloorSpawnID++;
        }

        if (SpawnAction == 1)
            SpawnQuestion();

        if (Question)
        {
            int dist = FloorSpawnID;
            if (QuestionPosZ < player.transform.position.z + Multiplier * ShowQuestionAfterDistance && WhatQuestion == 0)
            {
                WhatQuestion = Random.Range(0, questions.Length);
                ShowQuestions(WhatQuestion);
            }
        }
        else
        {
            SpawnLevel = true;
            StopQuestion();
        }

        if (player.Rotating == -1 && Question && SpawnLevel)
        {
            SpawnLevel = false;
            GameObject tempedge3 = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
            tempedge3.transform.Translate(Multiplier, 2, -3);
            tempedge3.transform.eulerAngles = new Vector3(tempedge3.transform.eulerAngles.z, tempedge3.transform.eulerAngles.y + 90, tempedge3.transform.eulerAngles.z);
            for (int i = 0; i < RenderDistance - 2; i++)
            {
                GameObject tempfloor = Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempfloor.transform.Translate((i + 2) * Multiplier, 0, 0);
                tempfloor.transform.eulerAngles = new Vector3(tempfloor.transform.eulerAngles.z, tempfloor.transform.eulerAngles.y + 90, tempfloor.transform.eulerAngles.z);
                GameObject tempedge = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempedge.transform.Translate((i + 2) * Multiplier, 2, 3);
                tempedge.transform.eulerAngles = new Vector3(tempedge.transform.eulerAngles.z, tempedge.transform.eulerAngles.y + 90, tempedge.transform.eulerAngles.z);
                GameObject tempedge2 = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempedge2.transform.Translate((i + 2) * Multiplier, 2, -3);
                tempedge2.transform.eulerAngles = new Vector3(tempedge2.transform.eulerAngles.z, tempedge2.transform.eulerAngles.y + 90, tempedge2.transform.eulerAngles.z);
                if (i > 0)
                {
                    RandomObj = Random.Range(0, Obstacle.Length);
                    GameObject tempobstacle = Instantiate(Obstacle[RandomObj], new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation) as GameObject;
                    tempobstacle.transform.Translate((i + 2) * Multiplier, 0, 0);
                    tempobstacle.transform.eulerAngles = new Vector3(tempobstacle.transform.eulerAngles.z, tempobstacle.transform.eulerAngles.y, tempobstacle.transform.eulerAngles.z);
                    tempobstacle.GetComponent<Obstacle>().XorZ = 1;
                }
            }
            FloorSpawnID += RenderDistance;
            QuestionCount += RenderDistance;
        }
        if (player.Rotating == 1 && Question && SpawnLevel)
        {
            SpawnLevel = false;
            GameObject tempedge3 = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
            tempedge3.transform.Translate(-Multiplier, 2, -3);
            tempedge3.transform.eulerAngles = new Vector3(tempedge3.transform.eulerAngles.z, tempedge3.transform.eulerAngles.y + 90, tempedge3.transform.eulerAngles.z);
            for (int i = 0; i < RenderDistance - 2; i++)
            {
                GameObject tempfloor = Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempfloor.transform.Translate((-2 - i) * Multiplier, 0, 0);
                tempfloor.transform.eulerAngles = new Vector3(tempfloor.transform.eulerAngles.z, tempfloor.transform.eulerAngles.y + 90, tempfloor.transform.eulerAngles.z);
                GameObject tempedge = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempedge.transform.Translate((-2 - i) * Multiplier, 2, 3);
                tempedge.transform.eulerAngles = new Vector3(tempedge.transform.eulerAngles.z, tempedge.transform.eulerAngles.y + 90, tempedge.transform.eulerAngles.z);
                GameObject tempedge2 = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation, Rotater.transform) as GameObject;
                tempedge2.transform.Translate((-2 - i) * Multiplier, 2, -3);
                tempedge2.transform.eulerAngles = new Vector3(tempedge2.transform.eulerAngles.z, tempedge2.transform.eulerAngles.y + 90, tempedge2.transform.eulerAngles.z);
                if (i > 0)
                {
                    RandomObj = Random.Range(0, Obstacle.Length);
                    GameObject tempobstacle = Instantiate(Obstacle[RandomObj], new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation) as GameObject;
                    tempobstacle.transform.Translate((-2 - i) * Multiplier, 0, 0);
                    tempobstacle.transform.eulerAngles = new Vector3(tempobstacle.transform.eulerAngles.z, tempobstacle.transform.eulerAngles.y + 180, tempobstacle.transform.eulerAngles.z);
                    tempobstacle.GetComponent<Obstacle>().XorZ = 1;
                }
            }
            FloorSpawnID += RenderDistance;
            QuestionCount += RenderDistance;
        }

        if (QuestionCount >= QuestionAfter && FloorSpawnID >= RenderDistance)
        {
            Question = true;
            QuestionPos = transform.position;
            QuestionPosZ = FloorSpawnID * Multiplier;

            for (int i = 0; i < 5; i++)
            {
                GameObject tempfloor = Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation) as GameObject;
                tempfloor.transform.Translate((i - 2) * Multiplier, 0, 0);
                tempfloor.transform.eulerAngles = new Vector3(tempfloor.transform.eulerAngles.z, tempfloor.transform.eulerAngles.y + 90, tempfloor.transform.eulerAngles.z);
                GameObject tempedge = Instantiate(Hedge, new Vector3(0, 0, FloorSpawnID * Multiplier), transform.rotation) as GameObject;
                tempedge.transform.Translate((i - 2) * Multiplier, 2, 3);
                tempedge.transform.eulerAngles = new Vector3(tempedge.transform.eulerAngles.z, tempedge.transform.eulerAngles.y + 90, tempedge.transform.eulerAngles.z);
            }
            QuestionCount = 0;
        }
    }

    void SpawnObject()
    {
        if (SpawnAction == 0)
        {
            RandomObj = Random.Range(0, Obstacle.Length);
            Instantiate(Obstacle[RandomObj], new Vector3(transform.position.x, 0, FloorSpawnID * Multiplier), transform.rotation);
        }
    }

    void SpawnQuestion()
    {
        Instantiate(QuestionObject, new Vector3(0, 0, transform.position.z), transform.rotation);
        for (int i = 0; i < 11; i++)
        {
            GameObject floor = Instantiate(Floor, Vector3.zero, transform.rotation) as GameObject;
            GameObject Hedge1 = Instantiate(Hedge, Vector3.zero, transform.rotation) as GameObject;
            GameObject Hedge2 = Instantiate(Hedge, Vector3.zero, transform.rotation) as GameObject;
            if (player.GameRotation % 360 == 0 || player.GameRotation % 360 == 180)
            {
                floor.transform.localPosition = new Vector3((i - 5) * RenderDistance, 0, transform.position.z);
                floor.transform.eulerAngles = new Vector3(0, 90, 0);
                Hedge1.transform.localPosition = new Vector3((i - 5) * RenderDistance, 2, transform.position.z - 3);
                Hedge1.transform.eulerAngles = new Vector3(0, 90, 0);
                Hedge2.transform.localPosition = new Vector3((i - 5) * RenderDistance, 2, transform.position.z + 3);
                Hedge2.transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
        SpawnAction = 0;
    }

    Vector3 IntPosition(Vector3 pos)
    {
        pos = new Vector3((int)pos.x, (int)pos.y, (int)pos.z);
        return pos;
    }

    [System.Serializable]
    public struct Questions
    {
        public string question;
        public string answer1;
        public string answer2;
        public int[] Changes;
    }

    void ShowQuestions(int i)
    {
        QuestionCanvas.GetComponent<CanvasGroup>().alpha = 1;
        QuestionText.text = questions[i - 1].question;
        Answer1Text.text = questions[i - 1].answer1;
        Answer2Text.text = questions[i - 1].answer2;
    }

    void StopQuestion()
    {
        QuestionCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void ChangeValues(string moveto)
    {
        if (moveto == "left")
        {
            player.Study += questions[WhatQuestion - 1].Changes[0];
            player.Social += questions[WhatQuestion - 1].Changes[1];
            player.Sleep += questions[WhatQuestion - 1].Changes[2];
        }
        if (moveto == "right")
        {
            player.Study += questions[WhatQuestion - 1].Changes[3];
            player.Social += questions[WhatQuestion - 1].Changes[4];
            player.Sleep += questions[WhatQuestion - 1].Changes[5];
        }
    }
}
