using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressBar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private Image progress;

    private void Awake()
    {
        progress = GetComponent<Image>();
    }

    private void Update()
    {
        if (videoPlayer.frameCount > 0)
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }
}
