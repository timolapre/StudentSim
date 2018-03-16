using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour {

    static public int PlayVideo;

    void Start()
    {
        PlayVideo = PlayerPrefs.GetInt("Video");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("NewGame", LoadSceneMode.Single);
        }

    }
    
    public void Playvideo()
    {
        transform.position = new Vector3(0,1,-7);
        GetComponent<VideoPlayer>().Play();
        Invoke("ChangeScene", 38);
    }

    private void ChangeScene()
    {
        PlayVideo = 1;
        PlayerPrefs.SetInt("Video", PlayVideo);
        SceneManager.LoadScene("NewGame", LoadSceneMode.Single);
    }
}
