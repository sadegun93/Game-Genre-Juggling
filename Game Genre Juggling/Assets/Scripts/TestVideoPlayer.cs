using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class TestVideoPlayer : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;

    string starter;

    public Flowchart test; //flowchart gets set calling playvideo
    //That way, when finished, it knows to just call the initial block of whatever flowchart played the video

    //Set appropriate variables before calling play video.
    //For example, before playing 1-2 for someone, set the variable so it knows that when its over, it displays the menu option for 1-2-1

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = FindObjectOfType<VideoPlayer>();
        videoPlayer.loopPointReached += StopVideo;

        //test = FindObjectOfType<Flowchart>();

        //starter = $"{Application.dataPath}/Resources/"; //All clips are located here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setChart(Flowchart test)
    {
        this.test = test;
    }

    public void StopVideo(VideoPlayer video)
    {
        video.Stop();

        test.ExecuteBlock("Test Start Block"); //Can execute a block afterwards to keep conversation going
        //The problem is knowing what block to execute
    }

    public void PlayVideo(string url)
    {
        //Assets/Resources/Part I - Group/Doc Games Part I 1 A.mov //Proper format?

        //videoPlayer.clip = Resources.Load(url) as VideoClip;
        //videoPlayer.clip = Resources.Load<Video>(url);

        //Application.dataPath goes right to Assets Folder
        //videoPlayer.url = starter + url;
        videoPlayer.url = $"file://{url}";
        //videoPlayer.url = $"file://{starter + url}";
        //videoPlayer.url = $"file://{Application.dataPath}";
        //Debug.Log($"Data Path: {Application.dataPath}");
        //file://D:/Applications/GitHub Repos/Game-Genre-Juggling/Game Genre Juggling/Assets/Resources/Part I - Group/Doc Games Part I 1 A.mov

        videoPlayer.Play();
    }
}
