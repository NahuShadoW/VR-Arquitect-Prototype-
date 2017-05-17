using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selector_Script : MonoBehaviour
{
    [SerializeField]
    EventSystem system;
    [SerializeField]
    GraphicRaycaster grRaycaster;
    [SerializeField]
    public PointerEventData data;
    public GameObject RaycastEndPoint;
    RaycastHit hit;
    float timer;


    private void Start()
    {
        data = new PointerEventData(system);
    }

    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, RaycastEndPoint.transform.position, Color.black);
        var Raycast = Physics.Raycast(transform.position, transform.forward, out hit, Vector3.Distance(transform.position, RaycastEndPoint.transform.position));
        if (Raycast && hit.transform.tag == "UI")
        {
            hit.transform.GetComponent<Button>().Select();
            if (Input.GetMouseButton(0) && timer < Time.time)
            {
                hit.transform.GetComponent<Image>().color = hit.transform.GetComponent<Button>().colors.pressedColor;
                hit.transform.GetComponent<Button>().OnPointerClick(data);
                timer = Time.time + 1f;
                StartCoroutine(ReturnToNormalColor(hit));
            }
        }
        else if (Raycast && hit.transform.tag == "InteractableObject")
        {
            if (Input.GetMouseButton(0) && timer < Time.time)
            {
                var a = hit.transform.GetComponentInChildren<InteractableObject_Script>();
                a.ToggleCanvas();
                timer = Time.time + 1f;
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

    }

    public IEnumerator ReturnToNormalColor(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.1f);
        hit.transform.GetComponent<Image>().color = hit.transform.GetComponent<Button>().colors.normalColor;
    }
}
