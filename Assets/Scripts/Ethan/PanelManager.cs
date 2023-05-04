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


    public GameObject panel; // R�f�rence vers le panneau � ouvrir
    public TextMeshProUGUI levelText;
    public Image resource; // image
    public TextMeshProUGUI cafeName; // nom
    public TextMeshProUGUI cafeCapacity; // capacit� de stockage du caf�
    public bool isPanelOpen = false; // �tat actuel du panneau

    public int cost;
    
    
    
    public ResourceManager resourceManager;

    public void Start()
    {
        
        // D�sactiver le panneau au d�marrage
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

