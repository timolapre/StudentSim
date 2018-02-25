using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Obstacle, Floor, Hedge, QuestionObject;
    public Player player;

    private int FloorSpawnID;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", 0, 1);
        InvokeRepeating("SpawnQuestion", 0, 10);
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.z > FloorSpawnID*10-100)
        {
            Instantiate(Floor, new Vector3(0, 0, FloorSpawnID * 10), transform.rotation);
            Instantiate(Hedge, new Vector3(3, 2, FloorSpawnID * 10), transform.rotation);
            Instantiate(Hedge, new Vector3(-3, 2, FloorSpawnID * 10), transform.rotation);
            FloorSpawnID++;
        }

	}

    void SpawnObject()
    {
        Instantiate(Obstacle, new Vector3(transform.position.x,0,transform.position.z), transform.rotation);
    }

    void SpawnQuestion()
    {
        Instantiate(QuestionObject, new Vector3(0, 0, transform.position.z), transform.rotation);
    }
}
