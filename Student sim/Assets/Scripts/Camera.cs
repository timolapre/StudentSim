using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public int PosID, NextPos;
    public float speed;

    public Transform[] Targets;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        MoveTo(Targets[PosID - 1]);

        //transform.position = transform.position + transform.forward * 1 * Time.deltaTime;
        //transform.eulerAngles = Vector3.RotateTowards(new Vector3(0,0,0), new Vector3(0,90,0),1f*Time.time,0);

        if (transform.position == Targets[2].position || transform.position == Targets[3].position)
            Reset();
        if (transform.position == Targets[1].position)
            PosID = NextPos;
    }

    void MoveTo(Transform newpos)
    {
        Vector3 targetDir = newpos.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position = Vector3.MoveTowards(transform.position,newpos.position,step);
    }

    public void Reset()
    {
        TextQuestions q = GetComponent<TextQuestions>();
        ChangeBars(q.id, PosID, q);
        q.id = Random.Range(1, q.questions.Length+1);
        transform.position = Targets[0].position;
        transform.rotation = Quaternion.Euler(0,0,0);
        PosID = 1;
        NextPos = 0;
    }

    private void ChangeBars(int id, int Option, TextQuestions q)
    {
        BarsManager bars = GetComponent<BarsManager>();

        for (int i = 0; i < 4; i++)
        {
            string textbar = null;
            int idtotext = i % 4;
            if (idtotext == 0)
                textbar = "Study";
            if (idtotext == 1)
                textbar = "Social";
            if (idtotext == 2)
                textbar = "Sleep";
            if (idtotext == 3)
                textbar = "Health";

            int ChangeValue = q.questions[id-1].Changes[i + (Option - 3) *4];

            bars.ChangeBars(textbar, ChangeValue);
        }
    }
}
