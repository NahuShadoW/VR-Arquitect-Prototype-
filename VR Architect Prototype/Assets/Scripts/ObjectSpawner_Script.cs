using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectSpawner_Script : MonoBehaviour
{
    
    [SerializeField]
    GameObject Spawner;
    

    public void InstantiateObject(GameObject obj)
    {
        Vector3 position = Spawner.transform.position;
        obj.transform.position = position;
        Instantiate(obj);
        
          
    }
}
