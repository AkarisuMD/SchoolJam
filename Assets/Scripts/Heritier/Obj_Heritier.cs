using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Heritier : MonoBehaviour
{
    /// <summary>
    /// met tout l'object par raport a son scriptable.
    /// </summary>
    /// <param name="heritier"></param>
    public void SetHeritier(Sc_Heritier heritier)
    {
        this.heritier = heritier;
        image.sprite = heritier.sprite;
        textBonus.text = heritier.bonus;
        textMalus.text = heritier.malus;
    }

    // reference a l'heritier.
    [SerializeField] private Sc_Heritier heritier;
    // affichage de l'heritier
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text textBonus;
    [SerializeField] private TMP_Text textMalus;

    /// <summary>
    /// Button pour selectionné l' heritier
    /// </summary>
    [SerializeField] private Button button;

    private void Start() { button.onClick.AddListener(OnClickAction); }
    private void OnClickAction()
    {
        GameManager.Instance.SelectHeritier(heritier);
    }
}
