using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;
using UnityEngine.Video;

//This is the options system for the menu integrated in both the template and example scene.
//This script is meant to be put onto the canvas, put it can work and can be put onto anything
//However since this interacts with the given menu specifically, it is better to put it there
//
//How this works:
//The function toggle is called inside a button, where the button has an onclick event that will call toggle
//At that point, it will pass in a string of the function that it wants to call (aka the name in string)
//And then given this code, it implements that feature.
//
//Note how the text on the button isn't the string that is being sent
//Note how spawn balls is not here (but is on the options menu in the "Template" scene), this was done to show that it is possible to call things outside of this menu (for reference it is in Instantiation.cs)
//However, it is not in an incredibly obvious spot, so despite both being adequate uses of the menu system, this usage is easier to follow

public class VideoSelectionMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public List<VideoClip> clipList;

    public void Toggle(string clip)
    {
        switch (clip)
        {
            case "Early":
                videoPlayer.clip = clipList[0];
                break;
            case "Modern":
                videoPlayer.clip = clipList[1];
                break;

            default:
                Debug.LogError("Menu item \"toggle\" not named correctly in button menu");
                break;
        }
    }

}
