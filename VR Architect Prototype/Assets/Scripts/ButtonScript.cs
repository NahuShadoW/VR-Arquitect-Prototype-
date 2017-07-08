using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    Transform target;

    void FixedUpdate()
    {
        transform.LookAt(2 * transform.position - GameObject.Find("Target").transform.position);
        //transform.LookAt(2 * transform.position - Vector3.up);
    }
}
