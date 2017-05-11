using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject_Script : MonoBehaviour {

    [SerializeField]
    GameObject interactableItemCanvasGO;
    public bool isCanvasActive = false;


   
    public void ToggleCanvas()
    {
        if (isCanvasActive)
        {
            interactableItemCanvasGO.SetActive(true);
            isCanvasActive = false;
        }
        else
        {
            interactableItemCanvasGO.SetActive(false);
            isCanvasActive = true;
        }
    }
}