using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reserve : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panel_Ressources;
    private bool panelIsOpen;
    public CafeObject cafeRegular;
    public CafeObject cafeBlond;
    public CafeObject cafeDeca;
    public CafeObject croissant;
    public CafeObject donut;
    public CafeObject muffin;
    public GameObject player;

    public ResourceManager resourceManager;
    

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
        panel.SetActive(false);
        panelIsOpen = false;
    }
    public void ButtonReguCoffee()
    {
        
        ButtonClicked("RegularCoffee", cafeRegular);
    }
    public void ButtonBlondCoffee()
    {

        ButtonClicked("BlondCoffee", cafeBlond);
    }
    public void ButtonDecaCoffee()
    {
        ButtonClicked("DecaCoffee", cafeDeca);
    }
    public void ButtonCroissant()
    {

        ButtonClicked("Croissant", croissant);
    }
    public void ButtonDonut()
    {

        ButtonClicked("Donut", donut);
    }
    public void ButtonMuffin()
    {

        ButtonClicked("Muffin", muffin);
    }
    public void ButtonClicked(string Name, CafeObject type)
    {
        switch(Name)
        {
            case "RegularCoffee":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money>type.costToRefill)
                { type.actualResource += 1; 
                    resourceManager.Money = resourceManager.Money-type.costToRefill;
                }
                break;
            case "BlondCoffee":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money > type.costToRefill)
                {
                    type.actualResource += 1;
                    resourceManager.Money = resourceManager.Money - type.costToRefill;
                }
                break;
            case "DecaCoffee":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money > type.costToRefill)
                {
                    type.actualResource += 1;
                    resourceManager.Money = resourceManager.Money - type.costToRefill;
                }
                break;
            case "Croissant":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money > type.costToRefill)
                {
                    type.actualResource += 1;
                    resourceManager.Money = resourceManager.Money - type.costToRefill;
                }
                break;
            case "Donut":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money > type.costToRefill)
                {
                    type.actualResource += 1;
                    resourceManager.Money = resourceManager.Money - type.costToRefill;
                }
                break;
            case "Muffin":
                if (type.actualResource < type.cafeMaxCapacity && resourceManager.Money > type.costToRefill)
                {
                    type.actualResource += 1;
                    resourceManager.Money = resourceManager.Money - type.costToRefill;
                }
                break;

            default:
                break;

        }
    }

    public void OnMouseDown()
    {
        player.GetComponent<PlayerBehaviour>().ClearActions();
        player.GetComponent<PlayerBehaviour>().isGoingToStorage = true;

        if (panelIsOpen == false) 
        { 
            panelIsOpen = true;
            panel.SetActive(true);
            panel_Ressources.SetActive(false);
        }
    }

    public void Close()
    {
        panel.SetActive(false);
        panelIsOpen = false;
        panel_Ressources.SetActive(true);
    }
}
