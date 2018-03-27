﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour {

    public Video vplayer;

    public void ChangeScene(string scene)
    {

        if (transform.name == "PlayButton")
        {
            vplayer.Playvideo();
        }
        else
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Spawner.FloorSpawnID = 0;
        Spawner.Question = false;
    }
}
