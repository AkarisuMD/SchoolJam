using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class NewCommand : MonoBehaviour
{
    public CommandesManager commandesManager;
    public ResourceManager resourceManager;
    public int price;
    
    private void Start()
    {
        commandesManager = CommandesManager.Instance;   
        resourceManager = ResourceManager.Instance; 
    }


    public void GetNewCommand()
    {
        commandesManager.NewCommand();
        price = commandesManager.regularCoffeePrice * commandesManager.regularcoffee
            + commandesManager.decaCoffeePrice * commandesManager.decaCoffee
            + commandesManager.blondCoffeePrice * commandesManager.blondCoffee
            + commandesManager.donutPrice * commandesManager.donut
            + commandesManager.painAuChocolatPrice * commandesManager.painAuChocolat
            + commandesManager.croissantPrice * commandesManager.croissant;
        price = price * resourceManager.Reputation;
        resourceManager.Money += price;

          

    }
}
