using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectSpawner_Script : MonoBehaviour
{

    [SerializeField]
    GameObject Spawner;
    PhysicsMenu_Script physic;

    private void Start()
    {
        physic = GameObject.Find("playerScale").GetComponent<PhysicsMenu_Script>();
    }

    public void InstantiateObject(GameObject obj)
    {
        try
        {
            Vector3 position = new Vector3(Spawner.transform.position.x, 0.5f, Spawner.transform.position.z);
            var gameObj = Instantiate(obj, position, Quaternion.identity);
            gameObj.tag = "InteractableObject";
            //--------------------------------------------------------------------------
            if (physic.isColliderOn)
            {
                var colliders = gameObj.GetComponents<BoxCollider>();
                foreach (BoxCollider col in colliders)
                {
                    col.enabled = true;
                }
            }
            else
            {
                var colliders = gameObj.GetComponents<BoxCollider>();
                foreach (BoxCollider col in colliders)
                {
                    col.enabled = false;
                }
            }
            //--------------------------------------------------------------------------
            if (physic.isKinematicOn)
            {
                Rigidbody rb = gameObj.GetComponent<Rigidbody>();
                rb.isKinematic = true;
            }
            else
            {
                Rigidbody rb = gameObj.GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    public void DeleteAllObjects()
    {
        var objs = GameObject.FindGameObjectsWithTag("InteractableObject");
        foreach (var obj in objs)
        {
            Destroy(obj, 0.2f);
        }
    }
}
