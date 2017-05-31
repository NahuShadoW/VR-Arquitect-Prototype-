using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class scale_camera_script : MonoBehaviour
{
    [SerializeField]
    VRTK_ControllerEvents LeftControllerEvents;
    [SerializeField]
    VRTK_ControllerEvents RightControllerEvents;
    [SerializeField]
    VRTK_TransformFollow LeftController;
    [SerializeField]
    VRTK_TransformFollow RightController;
    [SerializeField]
    Transform PlayerScaleTransform;
    [SerializeField]
    float distanceLR;
    [SerializeField]
    float smooth = 1f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (LeftControllerEvents.buttonOnePressed && RightControllerEvents.buttonOnePressed && LeftController == null)
        {
            var controllers = FindObjectsOfType<VRTK_TransformFollow>();
            LeftController = controllers[1];
            RightController = controllers[0];
        }
        //--------------------------------------------------------------------------
        if (LeftControllerEvents.buttonOnePressed && RightControllerEvents.buttonOnePressed && RightController != null)
        {
            distanceLR = (Vector3.Distance(RightController.transform.position, LeftController.transform.position));
            if (distanceLR > 0.5 && distanceLR < 15)
            {
                PlayerScaleTransform.localScale = new Vector3(distanceLR, distanceLR, distanceLR);
            }
        }
    }
}
