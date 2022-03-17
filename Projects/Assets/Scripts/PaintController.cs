using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintController : MonoBehaviour
{
    public GameObject brush;
    private LineRenderer linerend;
    private int points;
    private UnityEngine.XR.InputDevice device;
    private Color newColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        brush.GetComponent<Renderer>().material.SetColor("_Color", newColor);
    }

    // Update is called once per frame
    void Update()
    {
        brush.GetComponent<Renderer>().material.SetColor("_Color", newColor);
        bool triggerValue;
        var rightHandDevice = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevice);
        if (rightHandDevice.Count == 1)
        {
            device = rightHandDevice[0];
        }
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
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
        linerend.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        linerend.startColor = newColor;
        linerend.endColor = newColor;
        linerend.startWidth = 0.1f;
        linerend.endWidth = 0.1f;
        points = 0;
    }

    public void ChangeColor(Color selectedColor)
    {
        newColor = selectedColor;
    }
}