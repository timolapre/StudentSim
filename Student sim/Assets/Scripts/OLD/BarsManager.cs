using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsManager : MonoBehaviour {

    public float Study, Social, Sleep, Health;
    public Objects objects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        objects.Study.transform.localScale = new Vector3((float)(Study*(0.3/20)), objects.Study.transform.localScale.y, objects.Study.transform.localScale.z);
        objects.Social.transform.localScale = new Vector3((float)(Social * (0.3 / 20)), objects.Social.transform.localScale.y, objects.Social.transform.localScale.z);
        objects.Sleep.transform.localScale = new Vector3((float)(Sleep * (0.3 / 20)), objects.Sleep.transform.localScale.y, objects.Sleep.transform.localScale.z);
        objects.Health.transform.localScale = new Vector3((float)(Health * (0.3 / 20)), objects.Health.transform.localScale.y, objects.Health.transform.localScale.z);
    }

    public void ChangeBars(string id, int change)
    {
        if (id == "Study")
        {
            Study += change;
            if (change > 0)
                objects.Study.GetComponent<Renderer>().material.color = Color.green;
            else if(change < 0)
                objects.Study.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WhiteColor(objects.Study));
        }
        if (id == "Social")
        {
            Social += change;
            if (change > 0)
                objects.Social.GetComponent<Renderer>().material.color = Color.green;
            else if (change < 0)
                objects.Social.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WhiteColor(objects.Social));
        }
        if (id == "Sleep")
        {
            Sleep += change;
            if (change > 0)
                objects.Sleep.GetComponent<Renderer>().material.color = Color.green;
            else if (change < 0)
                objects.Sleep.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WhiteColor(objects.Sleep));
        }
        if (id == "Health")
        {
            Health += change;
            if (change > 0)
                objects.Health.GetComponent<Renderer>().material.color = Color.green;
            else if (change < 0)
                objects.Health.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WhiteColor(objects.Health));
        }
    }

    IEnumerator WhiteColor(GameObject x)
    {
        yield return new WaitForSeconds(1);
        x.GetComponent<Renderer>().material.color = Color.white;
    }

    [System.Serializable]
    public struct Objects
    {
        public GameObject Study;
        public GameObject Social;
        public GameObject Sleep;
        public GameObject Health;
    }
}
