using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Range(200, 300)]
    public int JumpForce;
    [Range(0, 25)]
    public int HorizontalSpeed;
    public int GameSpeed, GameRotation, Rotating;
    public float Study = 100, Social = 100, Sleep = 100;
    public GameObject StudyBar, SocialBar, SleepBar;

    public Text ScoreText;
    private static int Score, Years, Months, Weeks, Days;

    private bool OnFloor;
    private float MoveTime;

    public int Pos;
    private Vector2 MousePos, ConstantMousePos;

    Spawner spawner;

    Animator Anim;
    int JumpHash = Animator.StringToHash("jump-up");

    private KeyCode[] RightKeys = new KeyCode[] { KeyCode.RightArrow, KeyCode.D };
    private KeyCode[] LeftKeys = new KeyCode[] { KeyCode.LeftArrow, KeyCode.A };
    private KeyCode[] JumpKeys = new KeyCode[] { KeyCode.Space, KeyCode.UpArrow, KeyCode.W };

    // Use this for initialization
    void Start() {
        Anim = GetComponent<Animator>();
        spawner = transform.Find("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update() {
        /*if(OnFloor)
            GetComponent<Rigidbody>().useGravity = false;
        else
            GetComponent<Rigidbody>().useGravity = true;*/

        if (transform.position.z >= Spawner.QuestionPosZ)
        {
            if (Pos == 1)
            {
                Rotating = -1;
                spawner.ChangeValues("right");
                spawner.WhatQuestion = 0;
            }
            else if (Pos == -1)
            {
                Rotating = 1;
                spawner.ChangeValues("left");
                spawner.WhatQuestion = 0;
            }
            Pos = 0;
            Spawner.QuestionPosZ = 100000;
            Invoke("QuestionToFalse", 0.3f);
        }

        //ScoreManager();
        BarsManager();
        Score = (int)transform.position.z;
        transform.eulerAngles = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.M))
            Score = 1008;

        ScoreManager();

        if (Rotating == 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * GameSpeed);
        }
        else
        {
            Vector3 ppos = transform.position;
            transform.position = ppos;
        }

        if ((Swipe() == "Right" || KeyPressed("Right")) && Pos < 1)
        {
            Pos++;
            MoveTime = 0;
        }
        else if ((Swipe() == "Left" || KeyPressed("Left")) && Pos > -1)
        {
            Pos--;
            MoveTime = 0;
        }

        if ((Swipe() == "Jump" || KeyPressed("Jump")) && OnFloor)
        {
            GetComponent<Rigidbody>().AddForce(0, JumpForce, 0);
            OnFloor = false;
            Anim.SetBool("Jump", true);
        }

        if (OnFloor && Anim.GetBool("Jump"))
        {
            Anim.SetBool("Jump", false);
        }

        MoveTime += Time.deltaTime * HorizontalSpeed;
        //if(GameRotation%360 == 0 || GameRotation%360 == 180)
        transform.position = Vector3.Lerp(transform.position, new Vector3(Pos, transform.position.y, transform.position.z), MoveTime);
        //else if (GameRotation%360 == 0 || GameRotation%360 == 180)
        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Pos, transform.position.z), MoveTime);

        //transform.eulerAngles = new Vector3(0,GameRotation,0);

        if (Study <= 0 || Social <= 0 || Sleep <= 0 || Years == 3)
        {
            if(Years == 3)
                HighScore.HighScoreCheck(Score, 2, Study, Social, Sleep);
            else
                HighScore.HighScoreCheck(Score, 1, Study, Social, Sleep);

            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }

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
            if (MousePos.x < ConstantMousePos.x && Mathf.Abs(MousePos.x - ConstantMousePos.x) > Mathf.Abs(MousePos.y - ConstantMousePos.y))
                return "Right";
            if (MousePos.x > ConstantMousePos.x && Mathf.Abs(MousePos.x - ConstantMousePos.x) > Mathf.Abs(MousePos.y - ConstantMousePos.y))
                return "Left";
            if (MousePos.y < ConstantMousePos.y && Mathf.Abs(MousePos.x - ConstantMousePos.x) < Mathf.Abs(MousePos.y - ConstantMousePos.y))
                return "Jump";
        }

        return null;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Obstacle")
            Debug.Log("HIT");

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "Floor")
            OnFloor = true;
    }

    bool KeyPressed(string move)
    {
        if(move == "Right")
            for (int i = 0; i < RightKeys.Length; i++)
            {
                if (Input.GetKeyDown(RightKeys[i]))
                    return true;
            }
        if (move == "Left")
            for (int i = 0; i < LeftKeys.Length; i++)
            {
                if (Input.GetKeyDown(LeftKeys[i]))
                    return true;
            }
        if (move == "Jump")
            for (int i = 0; i < JumpKeys.Length; i++)
            {
                if (Input.GetKeyDown(JumpKeys[i]))
                    return true;
            }

        return false;
    }

    void BarsManager()
    {
        StudyBar.transform.localScale = new Vector3(Study,1,1);
        SocialBar.transform.localScale = new Vector3(Social,1, 1);
        SleepBar.transform.localScale = new Vector3(Sleep,1, 1);
    }

    void ScoreManager()
    {
        Years = Score / (28 * 12);
        Months = (Score - Years * (28*12)) / 28;
        Weeks = (Score - Months*28 - Years * (28 * 12)) / 7;
        Days = Score - Weeks * 7 - Months * 28 - Years * (28 * 12);
        ScoreText.text = "Years: " + Years + " Months: " + Months + " Weeks: " + Weeks + " Days: " + Days;
    }

    void QuestionToFalse()
    {
        Spawner.Question = false;
    }

}