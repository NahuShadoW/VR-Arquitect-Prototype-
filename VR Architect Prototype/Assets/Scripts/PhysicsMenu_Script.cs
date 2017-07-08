using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsMenu_Script : MonoBehaviour
{
    [SerializeField]
    Toggle gravityToggle;
    [SerializeField]
    Toggle kinematicsToggle;
    [SerializeField]
    Toggle collidersToggle;
    [SerializeField]
    public bool isGravityOn;
    [SerializeField]
    public bool isKinematicOn;
    [SerializeField]
    public bool isColliderOn;

    public void ToggleGravity()
    {
        if (!isGravityOn)
        {
            if (isColliderOn)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                isGravityOn = true;
            }
            else
            {
                print("Los colliders estan desactivados, la gravedad no se puede activar");
                gravityToggle.isOn = false;
            }
        }
        else
        {
            Physics.gravity = new Vector3(0, 0, 0);
            isGravityOn = false;
        }
    }

    public void ToggleKinematics()
    {
        if (!isKinematicOn)
        {
            var objs = GameObject.FindGameObjectsWithTag("InteractableObject");
            foreach (var rb in objs)
            {
                rb.GetComponent<Rigidbody>().isKinematic = true;
            }
            isKinematicOn = true;
            objs = null;
        }
        else
        {
            var objs = GameObject.FindGameObjectsWithTag("InteractableObject");
            foreach (var rb in objs)
            {
                rb.GetComponent<Rigidbody>().isKinematic = false;
            }
            isKinematicOn = false;
            objs = null;
        }
    }

    public void ToggleColliders()
    {

        if (!isColliderOn)
        {
            var objs = GameObject.FindGameObjectsWithTag("InteractableObject");
            foreach (var obj in objs)
            {
                foreach (BoxCollider bc in obj.GetComponents<BoxCollider>())
                {
                    bc.enabled = true;
                }

                foreach (MeshCollider meshcol in obj.GetComponentsInChildren<MeshCollider>())
                {
                    meshcol.enabled = true;
                }
            }
            isColliderOn = true;
            objs = null;
        }
        else
        {
            if (!isGravityOn)
            {
                var objs = GameObject.FindGameObjectsWithTag("InteractableObject");
                foreach (var obj in objs)
                {
                    foreach (BoxCollider bc in obj.GetComponents<BoxCollider>())
                    {
                        bc.enabled = false;
                    }

                    foreach (MeshCollider meshcol in obj.GetComponentsInChildren<MeshCollider>())
                    {
                        meshcol.enabled = false;
                    }
                }
                isColliderOn = false;
                objs = null;
            }
            else
            {
                print("Gravedad activada, los colliders no se pueden desactivar");
                collidersToggle.isOn = true;
            }
        }
    }
}
