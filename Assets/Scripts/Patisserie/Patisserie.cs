using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patisserie : Singleton<Patisserie>
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

    [SerializeField] private GameObject prefabPatisserie1;
    [SerializeField] private GameObject prefabPatisserie2;
    [SerializeField] private GameObject prefabPatisserie3;
    [SerializeField] private GameObject currentPatisserie;
    [SerializeField] private PatisserieType patisserieType;

    [SerializeField] private GameObject waitingObj;

    [SerializeField] private Image Choice1Image;
    [SerializeField] private Image Choice2Image;
    [SerializeField] private Image Choice3Image;


    private void OnMouseUp()
    {
        if (inUse)
        {
            if (!isFinish) return;
            GivePatisserie();
            return;
        }

        inUse = true;
        panel.SetActive(true);


        if (ResourceManager.Instance.croissant <= 0)
            Choice1Image.color = Color.gray;
        else Choice1Image.color = Color.white;

        if (ResourceManager.Instance.muffin <= 0)
            Choice2Image.color = Color.gray;
        else Choice2Image.color = Color.white;

        if (ResourceManager.Instance.donut <= 0)
            Choice3Image.color = Color.gray;
        else Choice3Image.color = Color.white;
    }

    public void Cancel()
    {
        inUse = false;
        panel.SetActive(false);
    }

    public void MakePatisserie1()
    {
        if (ResourceManager.Instance.croissant <= 0)
            ResourceManager.Instance.croissant -= 1;

            int a = 0;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }
    public void MakePatisserie2()
    {
        if (ResourceManager.Instance.muffin <= 0)
            ResourceManager.Instance.muffin -= 1;

            int a = 1;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }
    public void MakePatisserie3()
    {
        if (ResourceManager.Instance.donut <= 0)
            ResourceManager.Instance.donut -= 1;

            int a = 2;
        panel.SetActive(false);
        StartCoroutine(PreparationWaiting(a));
    }

    private IEnumerator PreparationWaiting(int a)
    {
        // Instantiate(waitingObj, canvas.transform);
        yield return new WaitForSeconds(preparationTime);
        SpawnPatisserie(a);
        isFinish = true;
    }

    private void SpawnPatisserie(int a)
    {
        switch (a)
        {
            case 0:
                currentPatisserie = Instantiate(prefabPatisserie1, position1.position, new Quaternion(0, 0, 0, 0));
                patisserieType = PatisserieType.CROISSANT;
                break;
            case 1:
                currentPatisserie = Instantiate(prefabPatisserie2, position1.position, new Quaternion(0, 0, 0, 0));
                patisserieType = PatisserieType.MUFFIN;
                break;
            case 2:
                currentPatisserie = Instantiate(prefabPatisserie3, position1.position, new Quaternion(0, 0, 0, 0));
                patisserieType = PatisserieType.DONUT;
                break;
            default:
                break;
        }
    }

    private void GivePatisserie()
    {
        currentPatisserie.transform.position = position2.position;

        inUse = false;
        isFinish = false;

        // give commande with coffee type
    }
}
