using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEditor;
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
    public TextMeshProUGUI costText;
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

    
    private CafeReserveUpgrade currentTypeUpgrade;
    public void Objcafe (CafeObject cafeType, CafeReserveUpgrade cafeReserveUpgrade)
    {
        currentTypeUpgrade = cafeReserveUpgrade;
        cafeType = cafeReserveUpgrade.cafeType; 
        
        resource.sprite = cafeType.spriteResource;
        cafeName.text = cafeType.cafename;
        cafeCapacity.text = "Capacity:" + cafeType.cafeMaxCapacity.ToString() + "+1";
        levelText.text = "Level:" + cafeType.Level.ToString(); 
        costText.text = "Upgrade:" + cafeType.costToUpgrade.ToString();
    }

    public void LevelUp()
    {
        cost = currentTypeUpgrade.cafeType.Level * 100 + 100;
        if (cost < resourceManager.Money)
        {
            resourceManager.Money = resourceManager.Money - cost;
            currentTypeUpgrade.cafeType.Level = currentTypeUpgrade.cafeType.Level + 1;
            levelText.text = "Level:" + currentTypeUpgrade.cafeType.Level.ToString();
            currentTypeUpgrade.cafeType.cafeMaxCapacity = currentTypeUpgrade.cafeType.cafeMaxCapacity + 1;
            cafeCapacity.text = currentTypeUpgrade.cafeType.cafeMaxCapacity.ToString();
            currentTypeUpgrade.cafeType.costToUpgrade = cost;
            Close();
        }
        else
        {
            Debug.Log("pas assez d'argent");
        }
    }

}

