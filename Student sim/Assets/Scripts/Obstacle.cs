using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Destroyer))]

public class Obstacle : MonoBehaviour {

    public int XorZ;
    private int ID;
    public float Ypos, YRot, XRot;
    public int[] ChangeValue;

    private bool collected;

    public Player player;
    Spawner spawner;

	// Use this for initialization
	void Start () {
        GetComponent<BoxCollider>().isTrigger = true;
        //ID = Random.Range(1, 4);
        //ChangeValue = Random.Range(-30,20);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawner = player.transform.Find("Spawner").GetComponent<Spawner>();
        if (XorZ == 0)
        {
            transform.position = new Vector3(Random.Range(-1, 2), Ypos, transform.position.z);
            transform.eulerAngles = new Vector3(XRot, YRot, 0);
        }
        else if (XorZ == 1)
        {
            transform.position = new Vector3(transform.position.x, Ypos, Spawner.FloorSpawnID * spawner.Multiplier + Random.Range(-1, 2) - spawner.RenderDistance * spawner.Multiplier);
            if(XRot != 0)
                transform.eulerAngles = new Vector3(XRot, transform.rotation.y, 0);
        }
        /*Renderer renderer = GetComponent<Renderer>();
        if (ID == 1)
            renderer.material.color = Color.blue;
        else if (ID == 2)
            renderer.material.color = Color.red;
        else if (ID == 3)
            renderer.material.color = Color.green;*/

        //if (ChangeValue > 0)
          //  transform.localScale = new Vector3(0.7f, 2, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0,0,-0.5f);

        if (transform.position.z < player.transform.position.z - 10)
            Destroy(gameObject);

        if (transform.position.z < -10)
            Destroy(gameObject);

        if (collected)
            CollectEffect();
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.transform.tag == "Player")
        {
            //if (ID == 1)
            {
                player.Study += ChangeValue[0];
                player.Social += ChangeValue[1];
                player.Sleep += ChangeValue[2];
                if(transform.name.Contains("Beer"))
                {
                    Player.Beers++;
                    if (Player.Beers >= 3)
                    {
                        player.transform.Find("Main Camera").GetComponent<Camera>().DrunkEffect(5f);
                        Player.Beers = 0;
                    }
                }
                collected = true;
            }
        }

    }

    void CollectEffect()
    {
        Vector3 NewPos = new Vector3(player.Pos-2,player.transform.position.y+3,player.transform.position.z+0.1f);
        transform.position = Vector3.Lerp(transform.position, NewPos,Time.deltaTime*3);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 5);
    }
} 
