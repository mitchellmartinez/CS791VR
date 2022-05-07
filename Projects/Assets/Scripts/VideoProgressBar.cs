using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressBar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject parentSlider;
    private Slider seek;
    private Image progress;
    private bool onDrag = false;

    private void Start()
    {
        progress = GetComponent<Image>();
        seek = parentSlider.GetComponent<Slider>();
    }

    private void Update()
    {
        if (!onDrag)
        { 
            seek.value = (float)videoPlayer.time / (float)videoPlayer.length;
        }
        else
        {
            videoPlayer.time = (float)seek.value * (float)videoPlayer.length;
        }
    }

    public void OnBeginDrag()
    {
        onDrag = true;
    }

    public void OnDragEnd()
    {
        onDrag = false;
    }
}