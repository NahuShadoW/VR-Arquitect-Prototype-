using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner_Script : MonoBehaviour
{

    private void Start()
    {
        Outline();
    }

    void Outline()
    {
        transform.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }
}
