using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

    Vector3 Angles;
    float Rot, rand;

	// Use this for initialization
	void Start () {
        rand = Random.Range(0, 360);
        Angles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        Rot = 8* Mathf.Sin(Time.time * 2 + rand);
        transform.eulerAngles = new Vector3(Angles.x + Rot, 90, Angles.z);
	}
}
