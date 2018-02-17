using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.Range(-1,2),transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0,-0.5f);

        if (transform.position.z < -10)
            Destroy(gameObject);
	}
}
