using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintController : MonoBehaviour
{
    public FlexibleColorPicker flexColor;
    public GameObject brush;
    private Material material;
    private LineRenderer brushTip;
    private LineRenderer linerend;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        material = brush.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = flexColor.color;
        linerend.startColor = flexColor.color;
        linerend.endColor = flexColor.color;
        bool triggerValue;
        var rightHandDevice = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevice);
        if (rightHandDevice[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            linerend.SetVertexCount(points + 1);
            linerend.SetPosition(points, brush.transform.position);
            points++;
        }
    }

    public void DrawLine()
    {
        GameObject line = new GameObject();
        linerend = line.AddComponent<LineRenderer>();
        linerend.startWidth = 0.1f;
        linerend.endWidth = 0.1f;
        points = 0;
    }
}
