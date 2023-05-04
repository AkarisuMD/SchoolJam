using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CafeReserveUpgrade : MonoBehaviour
{
    public CafeObject cafeType;
    public ResourceManager resourceManager;
    [SerializeField] private PanelManager panelManager;
    [SerializeField] private GameObject panel; // Référence vers le panneau à ouvrir
    
    
    public void Start()
    {
          resourceManager = ResourceManager.Instance;
           panelManager = PanelManager.Instance;
    }
    public void OnMouseDown()
    {
        
        if (panelManager.isPanelOpen == false)
        { 
            panel.SetActive(true);
            panelManager.isPanelOpen = true;

            panelManager.Objcafe(cafeType, this);
        }

    }
    public void LevelUp()
    {
        cafeType.Level = cafeType.Level + 1;
    }
    
}
