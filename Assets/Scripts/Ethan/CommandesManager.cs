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
        int _multi = Random.Range(1, 4);

        if (_multi == 1) 
        {
            int _a = Random.Range(1, 4);
            if (_a == 1) regularcoffee = 1;
            else if (_a == 2) blondCoffee = 1;
            else if (_a == 3) decaCoffee = 1;
            else Debug.LogError("Something goes wrong.");
        }
        if (_multi == 2)
        {
            int _b = Random.Range(1, 4);
            if (_b == 1) regularcoffee = 1;
            else if (_b == 2) blondCoffee = 1;
            else if (_b == 3) decaCoffee = 1;
            else Debug.LogError("Something goes wrong.");

            int _c = Random.Range(1, 4);
            if (_c == 1) croissant = 1;
            else if (_c == 2) painAuChocolat = 1;
            else if (_c == 3) donut = 1;
            else Debug.LogError("Something goes wrong.");
        }
        if (_multi == 3)
        {
            int _d = Random.Range(1, 4);
            if (_d == 1) regularcoffee = 1;
            else if (_d == 2) blondCoffee = 1;
            else if (_d == 3) decaCoffee = 1;
            else Debug.LogError("Something goes wrong.");

            int _e = Random.Range(1, 4);
            if (_e == 1) croissant = 2;
            else if (_e == 2) painAuChocolat = 2;
            else if (_e == 3) donut = 2;
            else Debug.LogError("Something goes wrong.");
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

        GameObject _etiquette = Instantiate(etiquette, layout.transform);

        string commandeString = "Order: \n\n";
        if (regularcoffee >= 1)
        {
            commandeString += regularcoffee + " Regular coffee\n";
        }
        if (blondCoffee >= 1)
        {
            commandeString += blondCoffee + " Blond coffee\n";
        }
        if (decaCoffee >= 1)
        {
            commandeString += decaCoffee + " Deca coffee\n";
        }
        if (donut >= 1)
        {
            commandeString += donut + " Donut(s)\n";
        }
        if (croissant >= 1)
        {
            commandeString += croissant + " Croissant(s)\n";
        }
        if (painAuChocolat >= 1)
        {
            commandeString += painAuChocolat + " Muffin(s)\n";
        }
        middleManEtiquette.tempText = commandeString;

        price = regularCoffeePrice * regularcoffee
            + decaCoffeePrice * decaCoffee
            + blondCoffeePrice * blondCoffee
            + donutPrice * donut
            + painAuChocolatPrice * painAuChocolat
            + croissantPrice * croissant;
        price = price * resourceManager.Reputation;
        resourceManager.Money += Mathf.CeilToInt(price);

        DialogueManager.Instance.CallDialogue(gb, cmd);
        gb.etiquette = _etiquette;

    }
    public float price = 0;
    public ResourceManager resourceManager => ResourceManager.Instance;
}
