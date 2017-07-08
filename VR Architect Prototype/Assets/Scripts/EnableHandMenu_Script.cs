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
    [SerializeField]
    GameObject ObjectSpawnerCanvasGO;
    [SerializeField]
    CanvasRotator canvasRotator;
    [SerializeField]
    GameObject controllerModelL;
    [SerializeField]
    GameObject controllerModelR;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (ControllerEvents.buttonTwoPressed && !HandCanvasGameObject.activeInHierarchy && timer < Time.time)
        {
            HandCanvasGameObject.SetActive(true);
            ObjectSpawnerCanvasGO.SetActive(true);
            controllerModelL.SetActive(false);
            timer = Time.time + cooldown;
        }
        else if (ControllerEvents.buttonTwoPressed && HandCanvasGameObject.activeInHierarchy && timer < Time.time)
        {
            HandCanvasGameObject.SetActive(false);
            ObjectSpawnerCanvasGO.SetActive(false);
            controllerModelL.SetActive(true);
            timer = Time.time + cooldown;
        }

        if (ControllerEvents.GetTouchpadAxis().x > 0.5)
        {
            canvasRotator.RotateCanvasLeft();
        }

        if (ControllerEvents.GetTouchpadAxis().x < -0.5)
        {
            canvasRotator.RotateCanvasRight();
        }
    }
}
