using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject_Script : MonoBehaviour
{
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    public void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    private void Update()
    {
        if (controller.GetPressDown(gripButton))
        {
            print("NOMAMESGRIP");
        }
        if (controller.GetPressDown(triggerButton))
        {
            print("NOMAMESTRIGGER");
        }
    }

    //[serializefield]
    //gameobject interactableitemcanvasgo;
    //public bool iscanvasactive = false;

    //public void togglecanvas()
    //{
    //    if (!iscanvasactive)
    //    {
    //        interactableitemcanvasgo.setactive(true);
    //        iscanvasactive = true;
    //    }
    //    else
    //    {
    //        interactableitemcanvasgo.setactive(false);
    //        iscanvasactive = false;
    //    }
    //}
}