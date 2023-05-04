using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EtiquetteSetUp : MonoBehaviour
{
    
    public TextMeshProUGUI text;

    public MiddleManEtiquette middleManEtiquette;

    private void Awake()
    {
        text.text = middleManEtiquette.tempText;
    }
    
}
