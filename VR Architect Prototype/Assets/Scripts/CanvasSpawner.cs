using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class CanvasSpawner : MonoBehaviour
{
    #region Attributes
    public Transform parent;
    public List<GameObject> CanvasElements = new List<GameObject>();
    public GameObject centrePos;
    public GameObject CanvasPrefab;
    public GameObject SpawnerCanvas;
    public GameObject ToggleCanvas;
    public Transform JoystickTransform;
    bool doneSpawning;
    #endregion

    public IEnumerator spawnWords()
    {
        var numPoints = 3;
        for (var pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float radius = 0.1f;
            var i = (pointNum * 1.0) / numPoints;
            float angle = (float)(i * Mathf.PI * 2);
            var x = Mathf.Sin(angle) * radius;
            var z = Mathf.Cos(angle) * radius;
            var pos = new Vector3(x, 0, z);
            #region Older positioning and instantiate method 
            //var pos = new Vector3(x, z, 0);
            //if (pointNum == 0)
            //{
            //    GameObject go = Instantiate(SpawnerCanvas, pos, parent.rotation) as GameObject;
            //    go.transform.SetParent(parent);
            //}
            //else if (pointNum == 1)
            //{
            //    GameObject go = Instantiate(ToggleCanvas, pos, parent.rotation) as GameObject;
            //    go.transform.SetParent(parent);
            //}
            //else
            //{
            //    GameObject go = Instantiate(CanvasPrefab, pos, parent.rotation) as GameObject;
            //    go.transform.SetParent(parent);
            //}
            #endregion
            CanvasElements[pointNum].transform.position = pos;
        }
        doneSpawning = true;
        transform.position = JoystickTransform.position;
        yield return null;
    }

    void Start()
    {
        StartCoroutine(spawnWords());
    }

    private void FixedUpdate()
    {
        if (doneSpawning)
            transform.position = JoystickTransform.position;
    }
}