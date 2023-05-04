using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cafetiere : Singleton<Cafetiere>
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private float preparationTime;
    private float realTimePreparation => preparationTime * GameManager.Instance.heritier.stats.multiplicateurTempsDePreparation;
    [SerializeField] private bool inUse;
    [SerializeField] private bool isFinish;
    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;

    [SerializeField] private GameObject prefabCoffee;
    [SerializeField] private GameObject currentCoffee;
    [SerializeField] private CoffeeType coffeeType;

    [SerializeField] private GameObject waitingObj;

    [SerializeField] private Image Choice1Image;
    [SerializeField] private Image Choice2Image;
    [SerializeField] private Image Choice3Image;

    private void OnMouseUp()
    {
        if (inUse)
        {
            if (!isFinish) return;
            GiveCoffee();
            return;
        }

        inUse = true;
        panel.SetActive(true);


        // IF IN STOCK1
        // Choice1Image.color = Color.gray;

        // IF IN STOCK2
        // Choice2Image.color = Color.gray;

        // IF IN STOCK3
        // Choice3Image.color = Color.gray;

    }

    public void Cancel()
    {
        inUse = false;
        panel.SetActive(false);
    }

    public void MakeCoffee1()
    {
        // IS IN STOCK

        int a = 0;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }
    public void MakeCoffee2()
    {
        // IS IN STOCK

        int a = 1;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }
    public void MakeCoffee3()
    {
        // IS IN STOCK

        int a = 2;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }

    private IEnumerator PreparationWaiting(int a)
    {
        // Instantiate(waitingObj, canvas.transform);
        yield return new WaitForSeconds(preparationTime);
        SpawnCoffee(a);
        isFinish = true;
    }

    private void SpawnCoffee(int a)
    {
        switch (a)
        {
            case 0:
                currentCoffee = Instantiate(prefabCoffee, position1.position, new Quaternion(0,0,0,0));
                coffeeType = CoffeeType.REGULAR;
                break; 
            case 1:
                currentCoffee = Instantiate(prefabCoffee, position1.position, new Quaternion(0, 0, 0, 0));
                coffeeType = CoffeeType.BLOND;
                break; 
            case 2:
                currentCoffee = Instantiate(prefabCoffee, position1.position, new Quaternion(0, 0, 0, 0));
                coffeeType = CoffeeType.DECA;
                break;
            default:
                break;
        }
    }

    private void GiveCoffee()
    {
        currentCoffee.transform.position = position2.position;

        inUse = false;
        isFinish = false;

        // give commande with coffee type
    }
}