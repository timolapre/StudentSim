using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public Player player;
    public GameObject Rotater;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Rotater = player.transform.Find("Rotater").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 2.5f && transform.position.x < 3.5f && transform.position.x != 3 && !Spawner.Question)
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        if (transform.position.x < -2.5f && transform.position.x > -3.5f && transform.position.x != -3 && !Spawner.Question)
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        if (transform.position.x < 0.5f && transform.position.x > -0.5f && transform.position.x != 0 && !Spawner.Question)
            transform.position = new Vector3(0, transform.position.y, transform.position.z);

        if (transform.position.z < player.transform.position.z - 20)
            Destroy(gameObject);

        if (player.Rotating != 0)
            transform.parent = Rotater.transform;
        else
            transform.parent = null;
    }
}
