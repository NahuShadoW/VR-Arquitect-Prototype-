using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

public class ObjectImporter : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    List<Button> buttonsInScene = new List<Button>();
    [SerializeField]
    ObjectSpawner_Script objSpawner;
    [SerializeField]
    List<GameObject> objectsInFolder = new List<GameObject>();
    #endregion

    private void Start()
    {
        buscarObjetosEnCarpeta();
    }

    public void buscarObjetosEnCarpeta()
    {
        //DirectoryInfo directory = new DirectoryInfo("Assets/Resources/");
        DirectoryInfo directory = new DirectoryInfo("C:/VRModeler/Resources");
        FileInfo[] directoryInfo = directory.GetFiles();
        int i = 0;
        foreach (var file in directoryInfo)
        {
            if (file.Extension == ".obj")
            {
                objectsInFolder.Add(OBJLoader.LoadOBJFile(file.FullName));
                objectsInFolder[i].transform.position = new Vector3(0f, -5000f, 0f);
                objectsInFolder[i].AddComponent<VRTK_InteractableObject>();
                objectsInFolder[i].AddComponent<VRTK_FixedJointGrabAttach>();
                objectsInFolder[i].AddComponent<VRTK_AxisScaleGrabAction>();
                objectsInFolder[i].AddComponent<Rigidbody>();

                var vrtkInteract = objectsInFolder[i].GetComponent<VRTK_InteractableObject>();
                vrtkInteract.touchHighlightColor = Color.yellow;
                vrtkInteract.isGrabbable = true;
                vrtkInteract.grabAttachMechanicScript = vrtkInteract.transform.GetComponent<VRTK_FixedJointGrabAttach>();
                vrtkInteract.secondaryGrabActionScript = vrtkInteract.transform.GetComponent<VRTK_AxisScaleGrabAction>();

                var vrtkFixedJoint = objectsInFolder[i].GetComponent<VRTK_FixedJointGrabAttach>();
                vrtkFixedJoint.precisionGrab = true;

                var vrtkAxisScaleGrab = objectsInFolder[i].GetComponent<VRTK_AxisScaleGrabAction>();
                vrtkAxisScaleGrab.uniformScaling = true;
                try
                {
                    for (int j = 0; j < objectsInFolder[i].transform.childCount; j++)
                    {
                        objectsInFolder[i].transform.GetChild(j).gameObject.AddComponent<MeshCollider>();
                        objectsInFolder[i].transform.GetChild(j).gameObject.GetComponent<MeshCollider>().convex = true;
                        objectsInFolder[i].transform.GetChild(j).transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                        objectsInFolder[i].transform.GetChild(j).transform.localPosition = new Vector3(0, 0, 0);
                        //objectsInFolder[i].transform.GetChild(j).gameObject.AddComponent<Rigidbody>();
                    }
                    objectsInFolder[i].AddComponent<InteractableObject_Hook_Script>();
                    int f = int.Parse(i.ToString());
                    buttonsInScene[i].onClick.AddListener(delegate { objSpawner.InstantiateObject(objectsInFolder[f]); });
                    buttonsInScene[i].transform.GetChild(0).GetComponent<Text>().text = file.Name.Replace(".obj", "").Replace("IKEA", "").Replace("3D", "").Replace("-", "").Replace("_", " ").ToUpper();
                    i++;
                }
                catch (Exception e)
                {
                    print("Error: " + e);
                }
            }
        }
    }

    //private void Start()
    //{
    //    DirectoryInfo directory = new DirectoryInfo("Assets/Resources/");
    //    FileInfo[] directoryInfo = directory.GetFiles();
    //    foreach (var file in directoryInfo)
    //    {
    //        if (file.Extension == ".obj")
    //        {
    //            text.text += file.Name + "\n";
    //            text2.text = text.text;
    //            //Debug.Log(f.Replace(".obj", ".mtl").ToString());
    //            OBJLoader.LoadOBJFile(file.FullName);
    //            print("Object " + file.Name + " instantiated!");
    //            OBJLoader.LoadMTLFile(file.FullName.Replace(".obj", ".mtl"));




    //            //print(file.FullName);
    //            //GameObject emptyPrefabWithMeshRenderer = new GameObject();
    //            //emptyPrefabWithMeshRenderer.AddComponent<MeshFilter>();
    //            //emptyPrefabWithMeshRenderer.AddComponent<MeshRenderer>();
    //            //Mesh MyMesh = FastObjImporter.Instance.ImportFile(file.FullName);
    //            //emptyPrefabWithMeshRenderer.GetComponent<MeshFilter>().mesh = MyMesh;
    //            //GameObject spawnedPrefab;
    //            //spawnedPrefab = Instantiate(emptyPrefabWithMeshRenderer, transform.position, transform.rotation);
    //        }
    //    }
    //}

}
