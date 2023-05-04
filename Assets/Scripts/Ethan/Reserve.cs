using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reserve : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool panelIsOpen;
    private void Start()
    {
        panel.SetActive(false);
        panelIsOpen = false;
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
