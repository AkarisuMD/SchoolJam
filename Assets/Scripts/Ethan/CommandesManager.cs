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
    public void NewCommand()
    {

        regularcoffee = Random.Range(0, 3);
        blondCoffee = Random.Range(0, 3);
        decaCoffee = Random.Range(0, 3);

        donut = Random.Range(0, 3);
        croissant = Random.Range(0, 3);
        painAuChocolat = Random.Range(0, 3);

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
        
    }



}
