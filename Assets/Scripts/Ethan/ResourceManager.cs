using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Resources;
using TMPro;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    public int Money = 300;
    public int RegularCoffee;
    public int BlondCoffee;
    public int DecaCoffee;
    public int Reputation;
    public int croissant;
    public int muffin;
    public int donut;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI reputationText;
    public TextMeshProUGUI regularCoffeeText;
    public TextMeshProUGUI blondCoffeeText;
    public TextMeshProUGUI decaCoffeeText;
    public TextMeshProUGUI croissantText;
    public TextMeshProUGUI muffinText;
    public TextMeshProUGUI donutText;

    public void GetMoney()
    {
        Money = Money + 100;
    }

    public void Update()
    {
        moneyText.text = Money.ToString() + "$";
        reputationText.text = "x" + Reputation.ToString();
        regularCoffeeText.text = RegularCoffee.ToString();
        blondCoffeeText.text = BlondCoffee.ToString();
        decaCoffeeText.text = DecaCoffee.ToString();
        croissantText.text = croissant.ToString();
        muffinText.text = muffin.ToString();
        donutText.text = donut.ToString();
    }
}
