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

    //[SerializeField]
    //GameObject interactableItemCanvasGO;
    //public bool isCanvasActive = false;

    //public void ToggleCanvas()
    //{
    //    if (!isCanvasActive)
    //    {
    //        interactableItemCanvasGO.SetActive(true);
    //        isCanvasActive = true;
    //    }
    //    else
    //    {
    //        interactableItemCanvasGO.SetActive(false);
    //        isCanvasActive = false;
    //    }
    //}
}