using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    [SerializeField]
    GameObject Canvas;

    public void RotateCanvasLeft()
    {
        //Canvas.transform.Rotate(Vector3.up * Time.deltaTime, 40f);
        Canvas.transform.Rotate(0, Time.deltaTime * 150, 0);
        //Canvas.transform.Rotate(Time.deltaTime * 50,0, 0);
    }

    public void RotateCanvasRight()
    {
        //Canvas.transform.Rotate(Vector3.up * Time.deltaTime, -40f);
        Canvas.transform.Rotate(0, -Time.deltaTime * 150, 0);
        //Canvas.transform.Rotate(-Time.deltaTime * 50,0, 0);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateCanvasLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateCanvasRight();
        }
    }
}
