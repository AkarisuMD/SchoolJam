using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject DialogueObj;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image_Personnage;
    [SerializeField] private Sprite fille_Sprite;
    [SerializeField] private Sprite garcon_Sprite;
    [SerializeField] private Sprite TUTO_Sprite;
    [SerializeField] private string dialogue_Tuto = "Hi! Are you the new one? Great, I was waiting for you. The store needed a bit of a revamp. \r\nYou'll see, it's a great place and the customers are really nice, even if they tend to talk a lot.\r\nAnyway, the coffee machine is ready to use, and if you need anything, look in your stock or buy equipment if necessary.";
    [SerializeField] private List<string> dialogue_Random;
    [SerializeField] private GuestBehaviour currentGuest;

    public void CallTuto()
    {
        MenuPause.Instance.isPaused = true;
        DialogueObj.SetActive(true);
        image_Personnage.sprite = TUTO_Sprite;
        text.text = dialogue_Tuto;
    }
    public void CallDialogue(GuestBehaviour gb, Commande cmd)
    {
        MenuPause.Instance.isPaused = true;
        DialogueObj.SetActive(true);
        switch (gb.clientType)
        {
            case ClientType.FILLE:
                image_Personnage.sprite = fille_Sprite;
                break;
            case ClientType.GARCON:
                image_Personnage.sprite = garcon_Sprite;
                break;
            default:
                break;
        }
        text.text = dialogue_Random[Random.Range(0, dialogue_Random.Count)];

    }
    public void SetPauseFalse()
    {
        MenuPause.Instance.isPaused = false;
    }
    public void SetGuestToState2()
    {
        MenuPause.Instance.isPaused = false;
        currentGuest.state = 2;
    }
}
