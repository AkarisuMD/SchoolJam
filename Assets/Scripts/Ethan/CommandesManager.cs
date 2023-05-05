using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandesManager : Singleton<CommandesManager>
{
    public int regularcoffee;
    public int blondCoffee;
    public int decaCoffee;

    public int donut;
    public int croissant;
    public int painAuChocolat;

    public int regularCoffeePrice = 10;
    public int croissantPrice = 12;
    public int blondCoffeePrice = 11;
    public int decaCoffeePrice = 12;
    public int donutPrice = 15;
    public int painAuChocolatPrice = 14;
    public MiddleManEtiquette middleManEtiquette;
    public GameObject layout;
    

    public GameObject etiquette;
    public void NewCommand(GuestBehaviour gb)
    {
        int _multi = Random.Range(1, 3);

        switch (_multi)
        {
            case 1:
                int _a = Random.Range(1, 3);
                if (_a == 1) regularcoffee = 1;
                else if (_a == 2) blondCoffee = 1;
                else if (_a == 3) decaCoffee = 1;
                else Debug.LogError("Something goes wrong.");

                break;
            case 2:
                int _b = Random.Range(1, 3);
                if (_b == 1) regularcoffee = 1;
                else if (_b == 2) blondCoffee = 1;
                else if (_b == 3) decaCoffee = 1;
                else Debug.LogError("Something goes wrong.");

                int _c = Random.Range(1, 3);
                if (_c == 1) croissant = 1;
                else if (_c == 2) painAuChocolat = 1;
                else if (_c == 3) donut = 1;
                else Debug.LogError("Something goes wrong.");

                break;
            case 3:
                int _d = Random.Range(1, 3);
                if (_d == 1) regularcoffee = 1;
                else if (_d == 2) blondCoffee = 1;
                else if (_d == 3) decaCoffee = 1;
                else Debug.LogError("Something goes wrong.");

                int _e = Random.Range(1, 3);
                if (_e == 1) croissant = 2;
                else if (_e == 2) painAuChocolat = 2;
                else if (_e == 3) donut = 2;
                else Debug.LogError("Something goes wrong.");

                break;
            default:
                break;
        }

        Commande cmd = new Commande()
        {
            RegularCoffee = regularcoffee,
            BlondCoffee = blondCoffee,
            DecaCoffee = decaCoffee,
            Croissant = croissant,
            Muffin = painAuChocolat,
            Donut = donut,
        };

        gb.commande = cmd;

        if (regularcoffee == 0 && blondCoffee == 0 && decaCoffee == 0 && donut == 0 && croissant == 0 && painAuChocolat == 0) 
        {
            regularcoffee = 1;
        }
        GameObject _etiquette = Instantiate(etiquette, layout.transform);

        string commandeString = "Commande: \n\n";
        if (regularcoffee > 1)
        {
            commandeString += regularcoffee + " café(s) régulier(s)\n";
        }
        if (blondCoffee > 1)
        {
            commandeString += blondCoffee + " café(s) blond(s)\n";
        }
        if (decaCoffee > 1)
        {
            commandeString += decaCoffee + " café(s) décaféiné(s)\n";
        }
        if (donut > 1)
        {
            commandeString += donut + " donut(s)\n";
        }
        if (croissant > 1)
        {
            commandeString += croissant + " croissant(s)\n";
        }
        if (painAuChocolat > 1)
        {
            commandeString += painAuChocolat + " pain(s) au chocolat\n";
        }

        middleManEtiquette.tempText = commandeString;


        DialogueManager.Instance.CallDialogue(gb, cmd);

    }
}
