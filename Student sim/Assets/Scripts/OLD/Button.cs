using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public int ID;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCam()
    {
        cam.PosID = 2;
        cam.NextPos = ID;
    }
}
