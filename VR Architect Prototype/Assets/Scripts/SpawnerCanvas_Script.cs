using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCanvas_Script : MonoBehaviour
{
    [SerializeField]
    Transform PlayerGOTransform;

    private void FixedUpdate()
    {
        this.transform.position = PlayerGOTransform.position;
    }
}
