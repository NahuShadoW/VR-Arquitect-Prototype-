using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableObject_Canvas_Script : MonoBehaviour
{

    GameObject PlayerRef;
    Transform canvasTransform;
    float startDistance;
    [SerializeField]
    VRTK_ControllerEvents ControllerEvents;

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("MainCamera");
        canvasTransform = this.transform;
        startDistance = canvasTransform.position.magnitude;
    }

    private void FixedUpdate()
    {
        //this.transform.LookAt(2 * transform.position - PlayerRef.transform.position);
    }
}
