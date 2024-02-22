using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{

    public string videoName;

    private void Start()
    {
        PlayDesiredVideo();
    }

    public void PlayDesiredVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
