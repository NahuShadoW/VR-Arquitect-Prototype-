using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class InteractableObject_Hook_Script : MonoBehaviour
{

    [SerializeField]
    private VRTK_InteractableObject InteractableObjScript;
    public float speed = 5;
    public Transform target;

    private void Start()
    {
        InteractableObjScript = GetComponent<VRTK_InteractableObject>();
        target = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        if (InteractableObjScript.IsGrabbed())
        {
            var controllerEvents = InteractableObjScript.GetGrabbingObject().GetComponent<VRTK_ControllerEvents>();
            if (controllerEvents.buttonTwoPressed)
            {
                Destroy(this.gameObject.GetComponent<Joint>(), 0.1f);
                //this.transform.position = InteractableObjScript.GetGrabbingObject().transform.position;
                this.transform.position = Vector3.Lerp(this.transform.position, GameObject.Find("Spawner_chico").transform.position, 0.05f);
                if (GameObject.Find("playerScale").GetComponent<PhysicsMenu_Script>().isKinematicOn)
                    this.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else
        {
            this.gameObject.AddComponent<Joint>();
        }
    }

}
