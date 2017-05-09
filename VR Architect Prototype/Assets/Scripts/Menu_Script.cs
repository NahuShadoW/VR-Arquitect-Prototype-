using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Script : MonoBehaviour
{

    public GameObject MenuObject;
    public GameObject FurnitureSubMenuObject;
    public GameObject StructureSubMenuObject;
    public GameObject MiscellaneousSubMenuObject;
    public string activeMenu;

    private void Start()
    {
        activeMenu = "none";
    }

    public void ActivateMenu(string active)
    {
        activeMenu = active;
        MenuObject.SetActive(true);
        FurnitureSubMenuObject.SetActive(false);
        StructureSubMenuObject.SetActive(false);
        MiscellaneousSubMenuObject.SetActive(false);
        PrintButtonMessage("Activate Menu");
    }
    public void DeactivateMenu(string active)
    {
        activeMenu = active;
        MenuObject.SetActive(false);
        FurnitureSubMenuObject.SetActive(false);
        StructureSubMenuObject.SetActive(false);
        MiscellaneousSubMenuObject.SetActive(false);
        PrintButtonMessage("Deactivate Menu");
    }

    public void ActivateFurnitureSubMenu(string active)
    {
        activeMenu = active;
        MenuObject.SetActive(false);
        FurnitureSubMenuObject.SetActive(true);
        StructureSubMenuObject.SetActive(false);
        MiscellaneousSubMenuObject.SetActive(false);
        PrintButtonMessage(active);
    }

    public void ActivateStructureSubMenu(string active)
    {
        activeMenu = active;
        MenuObject.SetActive(false);
        FurnitureSubMenuObject.SetActive(false);
        StructureSubMenuObject.SetActive(true);
        MiscellaneousSubMenuObject.SetActive(false);
        PrintButtonMessage(active);
    }

    public void ActivateMiscellaneousSubMenu(string active)
    {
        activeMenu = active;
        MenuObject.SetActive(false);
        FurnitureSubMenuObject.SetActive(false);
        StructureSubMenuObject.SetActive(false);
        MiscellaneousSubMenuObject.SetActive(true);
        PrintButtonMessage(active);
    }

    public void PrintButtonMessage(string Message)
    {
        print(Message);
    }
}
