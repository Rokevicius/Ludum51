using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    VideoPlayer videoPlayer;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "LoopMain.webm");
    }
}
