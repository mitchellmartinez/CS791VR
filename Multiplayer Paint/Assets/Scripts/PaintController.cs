using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintController : MonoBehaviour
{
    public FlexibleColorPicker flexColor;
    public GameObject brush;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = brush.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = flexColor.color;
    }
}
