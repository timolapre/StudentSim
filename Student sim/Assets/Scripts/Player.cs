using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int Jump;

    private int Pos;
    private Vector2 MousePos, ConstantMousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Swipe() == "Right" && Pos < 1)
            Pos++;
        else if (Swipe() == "Left" && Pos > -1)
            Pos--;

        if (Swipe() == "Jump")
            GetComponent<Rigidbody>().AddForce(0,Jump,0);

        transform.position = new Vector3(Pos,transform.position.y,-8);
	}

    private string Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePos = Input.mousePosition;
        }
        ConstantMousePos = Input.mousePosition;
        
        if (Input.GetMouseButtonUp(0))
        {
            if (MousePos.x < ConstantMousePos.x && Mathf.Abs(MousePos.x-ConstantMousePos.x) > Mathf.Abs(MousePos.y-ConstantMousePos.y))
                return "Right";
            if (MousePos.x > ConstantMousePos.x && Mathf.Abs(MousePos.x - ConstantMousePos.x) > Mathf.Abs(MousePos.y - ConstantMousePos.y))
                return "Left";
            if (MousePos.y < ConstantMousePos.y && Mathf.Abs(MousePos.x - ConstantMousePos.x) < Mathf.Abs(MousePos.y - ConstantMousePos.y))
                return "Jump";
        }

        return null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
            Debug.Log("HIT");
    }

}
