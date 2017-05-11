using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject_Canvas_Script : MonoBehaviour {

    [SerializeField]
    GameObject PlayerRef;
    Transform canvasTransform;
    float startDistance;

    private void Start()
    {
        canvasTransform = this.transform;
        startDistance = canvasTransform.position.magnitude;
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(2 * transform.position - PlayerRef.transform.position);
    }
}
