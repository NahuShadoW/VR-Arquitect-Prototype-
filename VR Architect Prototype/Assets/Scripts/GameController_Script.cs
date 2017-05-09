using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Script : MonoBehaviour {

    public Menu_Script menuScript;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M) && !menuScript.activeMenu.Equals("none"))
        {
            menuScript.DeactivateMenu("none");
        }
        else if(Input.GetKeyUp(KeyCode.M) && menuScript.activeMenu.Equals("none"))
        {
            menuScript.ActivateMenu("Menu");
        }



    }

}
