using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public int ID;
    public float ChangeValue;

    public Player player;

	// Use this for initialization
	void Start () {
        ID = Random.Range(1, 4);
        ChangeValue = Random.Range(-30,20);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transform.position = new Vector3(Random.Range(-1,2),transform.position.y,transform.position.z);

        Renderer renderer = GetComponent<Renderer>();
        if (ID == 1)
            renderer.material.color = Color.blue;
        else if (ID == 2)
            renderer.material.color = Color.red;
        else if (ID == 3)
            renderer.material.color = Color.green;

        if (ChangeValue > 0)
            transform.localScale = new Vector3(0.7f, 2, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0,0,-0.5f);

        if (transform.position.z < player.transform.position.z - 10)
            Destroy(gameObject);

        if (transform.position.z < -10)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.transform.tag == "Player")
        {
            if (ID == 1)
                player.Study += ChangeValue;
            if (ID == 2)
                player.Social += ChangeValue;
            if (ID == 3)
                player.Sleep += ChangeValue;
        }

    }
}
