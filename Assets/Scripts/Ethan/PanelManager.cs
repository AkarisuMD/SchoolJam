using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using Image = UnityEngine.UI.Image;

public class PanelManager : Singleton<PanelManager>
{


    public GameObject panel; // Référence vers le panneau à ouvrir
    public TextMeshProUGUI levelText;
    public Image resource; // image
    public TextMeshProUGUI cafeName; // nom
    public TextMeshProUGUI cafeCapacity; // capacité de stockage du café
    public bool isPanelOpen = false; // État actuel du panneau

    public int cost;
    
    
    
    public ResourceManager resourceManager;

    public void Start()
    {
        
        // Désactiver le panneau au démarrage
        panel.SetActive(false);
        resourceManager = ResourceManager.Instance;

    }
    public void Close()
    {
        panel.SetActive(false);
        isPanelOpen = false;
    }

    public void Upgrade(CafeReserveUpgrade cafeReserveUpgrade)
    {
        if (cost < resourceManager.Money)
        {
            cafeReserveUpgrade.LevelUp();
            resourceManager.Money = resourceManager.Money - cost;
        }
        else
        {
            Debug.Log("non t'es pauvre");
        }
    }

    public void Objcafe (CafeObject cafeType, CafeReserveUpgrade cafeReserveUpgrade)
    {
        cafeType = cafeReserveUpgrade.cafeType; 
        resource.sprite = cafeType.spriteResource;
        cafeName.text = cafeType.cafename;
        cafeCapacity.text = cafeType.cafeMaxCapacity.ToString();
        levelText.text = "Level:" + cafeType.Level.ToString(); 
    }

}

