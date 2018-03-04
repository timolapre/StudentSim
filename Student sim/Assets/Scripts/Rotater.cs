using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    private float MoveTime = -0.3f;
    private Player player;

	// Use this for initialization
	void Start () {
        player = transform.parent.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        if (player.Rotating == 1)
        {
            MoveTime += Time.deltaTime *5;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 270, 0), Mathf.Max(MoveTime,0));
            //Debug.Log("ROTATE LEFT");
        }
        if (player.Rotating == -1)
        {
            MoveTime += Time.deltaTime * 5;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 90, 0), MoveTime);
            //Debug.Log("ROTATE RIGHT");
        }
        if (player.Rotating == 0)
        {
            MoveTime = -Time.deltaTime*40;
            transform.eulerAngles = new Vector3(0,180,0);
        }
        if(MoveTime>=1)
            player.Rotating = 0;

    }
}
