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
        Vector3 position = Spawner.transform.position;
        obj.transform.position = position;
        var gameObj = Instantiate(obj);
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
}
