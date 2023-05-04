using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reserve : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool panelIsOpen;
    public CafeObject cafeRegular;
    public CafeObject cafeBlond;
    public CafeObject cafeDeca;
    public CafeObject croissant;
    public CafeObject donut;
    public CafeObject muffin;
    private void Start()
    {
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
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;
            case "BlondCoffee":
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;
            case "DecaCoffee":
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;
            case "Croissant":
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;
            case "Donut":
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;
            case "Muffin":
                if (type.actualResource < type.cafeMaxCapacity)
                { type.actualResource += 1; }
                break;

            default:
                break;

        }
    }

    public void OnMouseDown()
    {
        if (panelIsOpen == false) 
        { 
            panelIsOpen = true;
            panel.SetActive(true);
        }
    }

    public void Close()
    {
        panel.SetActive(false);
        panelIsOpen = false;
    }
}
