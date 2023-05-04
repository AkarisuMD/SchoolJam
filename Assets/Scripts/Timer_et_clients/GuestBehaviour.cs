using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestBehaviour : MonoBehaviour
{
    /*
recup temps de march et temps de marche a l entree du coffe shop d�pend de la file d'attente
recup place dans la ou les files d attente et place de table
get stade pour fil d'attente, en commande, vers la table, a table, sort.
donner des set timer a chacune de ses action (avec modifier) qui s'applique
    indiquer temps de march et temps de marche a l entree du coffe shop d�pend de la file d'attente
    get timer et vitesse du client
recuperer la source des timer pour le client
timer patience
timer satisfaction
timer wait de donner la commande DIFFERENCIER de wait pour avoir la commande une fois donn�
(autre fil d'attente autre part sur le contoir)

ce que veut le client
faire du malus si le client n'a pas ce qu il veut (paye par ratio que pour les bon �l�ments, perd les mauvais)
+ malus timer parce qu'il est deg + moins rep
faire un temps average, moins = plus de rep, plus = moins de rep, tromp� = moins de thune.
*/
    public GameObject waitingLine;
    public GameObject requestLine;
    public GameObject table;


    public float speed;
    public float waitingLineWalkTime;
    public float requestLineWalkTime;
    public float anger;
    public float angerLevelUntilUnhappy;
    public float timeSpentWaiting;
    public float waitingTimeTolerance;
    public int state;
    public int nextState;
    public int placeInLine;
    public float guestSpacing;

    public float satisfaction;

    public string[] meal;
    public int mealGeneration;
    public float mealComplexityMultiplier;

    public void Start()
    {
        waitingLine = GameObject.Find("trgt1").gameObject;
        requestLine = GameObject.Find("trgt2").gameObject;
    }

    public void Update()
    {
        timeSpentWaiting += Time.deltaTime;
        if (state == nextState)
        {
            nextState = state + 1;
            timeSpentWaiting = 0;
        }

        if(timeSpentWaiting > waitingTimeTolerance)
        {
            anger += 1f * Time.deltaTime;
        }

        if(state == 0)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z), 
                                                                     new Vector3(waitingLine.gameObject.transform.position.x, 0, waitingLine.gameObject.transform.position.z + placeInLine * guestSpacing), speed / 100);

            if (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z) == new Vector3(waitingLine.gameObject.transform.position.x, 0, waitingLine.gameObject.transform.position.z))
            {
                state = nextState;
            }
        }

        if (state == 1)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z), 
                                                                     new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, 0, requestLine.gameObject.transform.position.z), speed / 100);
            //la commande a �t� accept�
        }

        if (state == 2)
        {
            //wait avec la commande
        }

        if (state == 3)
        {
            //go table
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z),
                                                                     new Vector3(table.gameObject.transform.position.x, 0, table.gameObject.transform.position.z), speed / 100);
        }

        if (state == 4)
        {
            //gtfo
        }
    }
}