using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitVRModeler_Script : MonoBehaviour
{

    [SerializeField]
    Text ExitButtonText;
    bool exit;
    bool cRunning;

    public void requestExitConfirmation()
    {
        StartCoroutine(exitApp());
    }

    public IEnumerator exitApp()
    {
        cRunning = true;
        ExitButtonText.text = "PRESS THIS BUTTON AGAIN TO EXIT";
        if (exit)
        {
            Application.Quit();
            print("EXIT APP");
        }
        exit = true;
        yield return new WaitForSeconds(5f);
        ExitButtonText.text = "EXIT VR MODELER";
        exit = false;
        cRunning = false;
        yield return null;
    }
}
