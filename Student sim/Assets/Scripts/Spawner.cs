using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Obstacle;
    public Player player;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnObject()
    {
        Instantiate(Obstacle, transform.position, transform.rotation);
    }
}
