using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_Script : MonoBehaviour
{
    [SerializeField]
    GameObject playerRef;
    [SerializeField]
    GameObject dummy;

    public void InstantiateObject(GameObject obj)
    {
        Instantiate(obj, dummy.transform.position, Quaternion.identity);
    }
}
