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
    public int croissant;
    public int muffin;
    public int donut;

    [Range(0.5f, 2f)]
    public float Reputation;
    private List<float> reputationList = new();

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI reputationText;
    public TextMeshProUGUI regularCoffeeText;
    public TextMeshProUGUI blondCoffeeText;
    public TextMeshProUGUI decaCoffeeText;
    public TextMeshProUGUI croissantText;
    public TextMeshProUGUI muffinText;
    public TextMeshProUGUI donutText;

    public TextMeshProUGUI regularCoffeeText2;
    public TextMeshProUGUI blondCoffeeText2;
    public TextMeshProUGUI decaCoffeeText2;
    public TextMeshProUGUI croissantText2;
    public TextMeshProUGUI muffinText2;
    public TextMeshProUGUI donutText2;

    public void AddReputation(float value)
    {
        reputationList.Add(value);

        float _global = 0;
        for (int i = 0; i < reputationList.Count; i++)
        {
            _global += reputationList[i];
        }

        Reputation = _global / reputationList.Count;
    }

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


        regularCoffeeText2.text = RegularCoffee.ToString();
        blondCoffeeText2.text = BlondCoffee.ToString();
        decaCoffeeText2.text = DecaCoffee.ToString();
        croissantText2.text = croissant.ToString();
        muffinText2.text = muffin.ToString();
        donutText2.text = donut.ToString();
    }
}
