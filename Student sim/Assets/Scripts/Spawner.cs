using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static int QuestionPosZ = 1000;

    public int Mult;

    public GameObject Obstacle, Floor, Hedge, QuestionObject;
    public Player player;

    private int FloorSpawnID, SpawnAction;
    private int QuestionAfter = 30;
    public static bool Question;
    private Vector3 QuestionPos;

	// Use this for initialization
	void Start () {
        //InvokeRepeating("SpawnObject", 0, 1f);
        //InvokeRepeating("SpawnQuestion", 0, 10);  
    }   
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (SpawnAction == 0 && player.transform.position.z > FloorSpawnID*Mult-Mult*10 && !Question)
        {
            QuestionAfter--;
            Instantiate(Floor, player.transform.forward*FloorSpawnID*Mult, transform.rotation);
            //Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * 10), transform.rotation);
            Instantiate(Hedge, new Vector3(3, 2, FloorSpawnID * Mult), transform.rotation);
            Instantiate(Hedge, new Vector3(-3, 2, FloorSpawnID * Mult), transform.rotation);
            SpawnObject();
            FloorSpawnID++;
        }

        if (Input.GetKeyDown(KeyCode.P))
            SpawnAction = 1;

        if (SpawnAction == 1)
            SpawnQuestion();

        if(QuestionAfter == 0)
        {
            Question = true;
            QuestionPos = transform.position;
            QuestionPosZ = FloorSpawnID * Mult;

            for (int i = 0; i < 5; i++)
            {
                GameObject tempfloor = Instantiate(Floor, transform.forward * FloorSpawnID * Mult, transform.rotation) as GameObject;
                tempfloor.transform.Translate((i-2)*Mult,0,0);
                tempfloor.transform.eulerAngles = new Vector3(tempfloor.transform.eulerAngles.z, tempfloor.transform.eulerAngles.y+90, tempfloor.transform.eulerAngles.z);
                GameObject tempedge = Instantiate(Hedge, transform.forward * FloorSpawnID * Mult, transform.rotation) as GameObject;
                tempedge.transform.Translate((i - 2) * Mult, 2, 3);
                tempedge.transform.eulerAngles = new Vector3(tempedge.transform.eulerAngles.z, tempedge.transform.eulerAngles.y + 90, tempedge.transform.eulerAngles.z);
            }
            QuestionAfter = 30;
        }
	}

    void SpawnObject()
    {
        if(SpawnAction == 0)
            Instantiate(Obstacle, new Vector3(transform.position.x,0, FloorSpawnID * Mult), transform.rotation);
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
                floor.transform.localPosition = new Vector3((i-5)*10,0,transform.position.z);
                floor.transform.eulerAngles = new Vector3(0,90,0);
                Hedge1.transform.localPosition = new Vector3((i - 5) * 10, 2, transform.position.z - 3);
                Hedge1.transform.eulerAngles = new Vector3(0, 90, 0);
                Hedge2.transform.localPosition = new Vector3((i - 5) * 10, 2, transform.position.z + 3);
                Hedge2.transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
        SpawnAction = 0;
    }
}
