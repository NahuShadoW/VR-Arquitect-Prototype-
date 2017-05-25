using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EnableHandMenu_Script : MonoBehaviour
{

    [SerializeField]
    VRTK_ControllerEvents ControllerEvents;
    float timer;
    [SerializeField]
    float cooldown;
    [SerializeField]
    GameObject HandCanvasGameObject;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (ControllerEvents.buttonTwoPressed && !HandCanvasGameObject.activeInHierarchy && timer < Time.time)
        {
            HandCanvasGameObject.SetActive(true);
            timer = Time.time + cooldown;
        }
        else if (ControllerEvents.buttonTwoPressed && HandCanvasGameObject.activeInHierarchy && timer < Time.time)
        {
            HandCanvasGameObject.SetActive(false);
            timer = Time.time + cooldown;
        }
    }
}
