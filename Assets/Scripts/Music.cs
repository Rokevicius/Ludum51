using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Music : MonoBehaviour
{
    string WavPath = "https://live.hunter.fm/lofi_high";
    public AudioSource Source;
    private IEnumerator Start()
    {
        using (var webRequest = UnityWebRequestMultimedia.GetAudioClip(WavPath, AudioType.WAV))
        {
            ((DownloadHandlerAudioClip)webRequest.downloadHandler).streamAudio = true;

            webRequest.SendWebRequest();
            while (!webRequest.isNetworkError && webRequest.downloadedBytes < 1024)
                yield return null;

            if (webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
                yield break;
            }

            var clip = ((DownloadHandlerAudioClip)webRequest.downloadHandler).audioClip;
            Source.clip = clip;
            Source.Play();
        }
    }

}
