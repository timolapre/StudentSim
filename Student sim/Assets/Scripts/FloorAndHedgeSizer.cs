using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAndHedgeSizer : MonoBehaviour {

    private Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, spawner.Multiplier);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
