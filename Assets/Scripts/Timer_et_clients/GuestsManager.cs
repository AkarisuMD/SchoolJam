using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestsManager : MonoBehaviour
{
    /*
 * array avec les clients [] (comme monstres VS)
faire timer spawn rate faire un random pour le faire arriver plus ou moins vite (pas trop éloigner de l'av)
faire un array client
faire des array pour fil d'attente, en commande, vers la table, a table, sort.
(autre fil d'attente autre part sur le contoir)
+ il y a de rep dans le coffee shop + il y a de la clientelle*/
    public GameObject randomGuest;
    public GameObject newGuest;
    public GameObject firstInQueue;
    public GameObject guestWithMeal;
    public GameObject guestleaving;

    public List<GameObject> waitingLine;
    public List<GameObject> requestLine;
    public List<GameObject> onTable;
    public List<GameObject> allTables;
    public int[] originTableKey;
    public int[] currentTableKey;
    public int wantedTable;
    public int findingFreeTableTries;

    public int maxGuestsInWaitingLine;
    public int maxGuestsInRequestLine;

    public float spawnTime;
    public float averageSpawnTime;
    public float nextSpawnTime;
    public float reputaionModifier;

    public void Start()
    {
        originTableKey = new int[8] { 4, 1, 6, 7, 2, 8, 3, 5 };
        currentTableKey = originTableKey;
    }

    public void Update()
    {
        if(waitingLine.Count < maxGuestsInWaitingLine) 
        {
            spawnTime += Time.deltaTime;
        }

        if (spawnTime > averageSpawnTime)
        {
            spawnTime = 0;
            newGuest = Instantiate(randomGuest);
            waitingLine.Add(newGuest);
            newGuest.GetComponent<GuestBehaviour>().placeInLine = waitingLine.Count - 1;
        }

        GuestWaitingLineManagement();
        GuestRequestingLineManagement();
        GuestOnTableManagement();
        GuestLeavingManagement();
        }

    public void GuestWaitingLineManagement()
    {
        try
        {
            if (requestLine.Count >= maxGuestsInRequestLine) //*****************************
            {
                newGuest.GetComponent<GuestBehaviour>().placeInLine = waitingLine.Count;
            }
        }
        catch (UnassignedReferenceException) { }
    }


    public void GuestRequestingLineManagement()
    {
        try
        {
            if (waitingLine[0].GetComponent<GuestBehaviour>().state >= 1)
            {
                firstInQueue = waitingLine[0];
                waitingLine.Remove(firstInQueue);

                requestLine.Add(firstInQueue);
                firstInQueue.GetComponent<GuestBehaviour>().placeInLine = requestLine.Count - 1;
            }

            if (requestLine.Count < maxGuestsInRequestLine) //*****************************
            {
                for (int i = 0; i < waitingLine.Count; i++)
                {
                    waitingLine[i].GetComponent<GuestBehaviour>().placeInLine = i;
                }
            }
        }
        catch (ArgumentOutOfRangeException) { }
    }


    public void GuestOnTableManagement()
    {
        try
        {
            for (int i = 0; i < requestLine.Count; i++)
            {
                if (requestLine[i].GetComponent<GuestBehaviour>().state == 3)
                {
                    guestWithMeal = requestLine[i];
                    requestLine.Remove(guestWithMeal);

                    for (int j = 0; j < requestLine.Count; j++)
                    {
                        requestLine[j].GetComponent<GuestBehaviour>().placeInLine = j;
                    }

                    onTable.Add(guestWithMeal);

                    if (onTable.Count <= 8)
                    {
                        wantedTable = currentTableKey[(int)UnityEngine.Random.Range(0, 8)];
                        while (currentTableKey[wantedTable] > 99)
                        {
                            wantedTable = originTableKey[wantedTable];
                        }
                        Debug.Log(wantedTable);
                        guestWithMeal.GetComponent<GuestBehaviour>().table = allTables[wantedTable];
                        currentTableKey[i] = onTable.IndexOf(guestWithMeal) * 100 + wantedTable;
                    }
                }
            }
        }
        catch (UnassignedReferenceException) { }
    }


    public void GuestLeavingManagement()
    {
        try
        {
            for (int i = 0; i < onTable.Count; i++)
            {
                if (onTable[i].GetComponent<GuestBehaviour>().state == 4)
                {
                    guestleaving = onTable[i];
                    while (currentTableKey[wantedTable] >= onTable.IndexOf(guestleaving) * 100 &&
                          currentTableKey[wantedTable] <= onTable.IndexOf(guestleaving) * 100 + 99)
                    {
                        wantedTable = originTableKey[wantedTable];
                    }
                    onTable.Remove(guestleaving);
                    currentTableKey[wantedTable] = originTableKey[wantedTable];
                }
            }
        }
        catch (NullReferenceException) { }
    }
}
