using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestsManager : Singleton<GuestsManager>
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
    public GameObject waitingTable;

    public List<GameObject> waitingLine;
    public List<GameObject> requestLine;
    public List<GameObject> onTable;
    public List<GameObject> allTables;
    public List<GameObject> waitingOnTables;
    public int[] originTableKey;
    public float[] currentTableKey;
    public int wantedTable;
    public int findingFreeTableTries;

    public int maxGuestsInWaitingLine;
    public int maxGuestsInRequestLine;

    public float spawnTime;
    public float averageSpawnTime;
    public float nextSpawnTime;
    public float reputationModifier;
    public int x;

    public Commande commandeToGive;

    public void Start()
    {
        originTableKey = new int[8] { 4, 2, 7, 6, 1, 0, 5, 3 };
        currentTableKey = new float[8] { 4, 2, 7, 6, 1, 0, 5, 3 };
    }

    public void MakeNewCommandeToGive()
    {
        commandeToGive = new()
        {
            RegularCoffee = 0,
            BlondCoffee = 0,
            DecaCoffee = 0,
            Croissant = 0,
            Muffin = 0,
            Donut = 0,
        };
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
            newGuest = Instantiate(randomGuest, this.gameObject.transform.position, this.gameObject.transform.rotation);
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
            if (requestLine.Count >= maxGuestsInRequestLine)
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

            if (requestLine.Count < maxGuestsInRequestLine)
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
                    wantedTable = (int)UnityEngine.Random.Range(0, 7);

                    x = 0;
                    while (currentTableKey[wantedTable] > 99 && x <= 8)
                    {
                        wantedTable = originTableKey[wantedTable];
                        x++;
                        Debug.Log("LoopIsRunning");
                        Debug.Log(x);
                    }

                    if (waitingOnTables.Contains(guestWithMeal) == false)
                    {
                        waitingOnTables.Add(guestWithMeal);
                        guestWithMeal.GetComponent<GuestBehaviour>().table = waitingTable;
                    }

                    if (waitingOnTables.IndexOf(guestWithMeal) == 0 && x <= 8)
                    {
                        requestLine.Remove(guestWithMeal);
                        waitingOnTables.Remove(guestWithMeal);
                        guestWithMeal.GetComponent<GuestBehaviour>().table = allTables[wantedTable];
                        currentTableKey[wantedTable] = ((float)originTableKey[wantedTable] + 1) * 100000 + guestWithMeal.GetComponent<GuestBehaviour>().guestID;
                    }

                    x = 0;

                    if (onTable.Contains(guestWithMeal) == false && waitingOnTables.Contains(guestWithMeal) == false)
                    {
                        onTable.Add(guestWithMeal);
                    }

                    for (int j = 0; j < requestLine.Count; j++)
                    {
                        requestLine[j].GetComponent<GuestBehaviour>().placeInLine = j;
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
                    wantedTable = (int)UnityEngine.Random.Range(0, 7);
                    x = 0;

                    while ( (originTableKey[wantedTable] + 1) * 100000 + guestleaving.GetComponent<GuestBehaviour>().guestID != currentTableKey[wantedTable] && x <= 8)
                    {
                        wantedTable = originTableKey[wantedTable];
                        x++;
                        Debug.Log((originTableKey[wantedTable] + 1) * 100000 + guestleaving.GetComponent<GuestBehaviour>().guestID);
                        Debug.Log(currentTableKey[wantedTable]);
                    }
                    onTable.Remove(guestleaving);
                    currentTableKey[wantedTable] = originTableKey[wantedTable];

                }
            }
        }
        catch (NullReferenceException) { }
    }
}
