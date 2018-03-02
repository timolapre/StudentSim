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
        if (transform.position.z < player.transform.position.z - 20)
            Destroy(gameObject);

        if (player.Rotating != 0)
            transform.parent = Rotater.transform;
        else
            transform.parent = null;
    }
}
