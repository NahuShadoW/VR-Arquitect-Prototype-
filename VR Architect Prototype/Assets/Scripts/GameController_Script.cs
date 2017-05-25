using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Script : MonoBehaviour
{

    public Menu_Script menuScript;
    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device leftController { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    public void Start()
    {
    }

    private void Update()
    {
        if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && !menuScript.activeMenu.Equals("none"))
        {
            menuScript.DeactivateMenu("none");
        }
        else if (leftController.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) && menuScript.activeMenu.Equals("none"))
        {
            menuScript.ActivateMenu("Menu");
        }



    }

}
