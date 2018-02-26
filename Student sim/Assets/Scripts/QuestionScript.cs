using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour {

    public GameObject text;

	// Use this for initialization
	void Start () {
        Instantiate(text, new Vector3(transform.position.x, transform.position.y+0.25f, transform.position.z - 0.51f), transform.rotation, transform);
        //text.GetComponent<TextMesh>().text = "TESTING";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
