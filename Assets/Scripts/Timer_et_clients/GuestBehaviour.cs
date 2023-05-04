using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuestBehaviour : MonoBehaviour
{
    /*
recup temps de march et temps de marche a l entree du coffe shop dépend de la file d'attente
recup place dans la ou les files d attente et place de table
get stade pour fil d'attente, en commande, vers la table, a table, sort.
donner des set timer a chacune de ses action (avec modifier) qui s'applique
    indiquer temps de march et temps de marche a l entree du coffe shop dépend de la file d'attente
    get timer et vitesse du client
recuperer la source des timer pour le client
timer patience
timer satisfaction
timer wait de donner la commande DIFFERENCIER de wait pour avoir la commande une fois donné
(autre fil d'attente autre part sur le contoir)

ce que veut le client
faire du malus si le client n'a pas ce qu il veut (paye par ratio que pour les bon éléments, perd les mauvais)
+ malus timer parce qu'il est deg + moins rep
faire un temps average, moins = plus de rep, plus = moins de rep, trompé = moins de thune.
*/
    public GameObject waitingLine;
    public GameObject requestLine;
    public GameObject table;
    public GameObject exitDoor;


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

    [Range (0.5f, 2f)]
    public float satisfaction;

    public int mealGeneration;
    public float mealComplexityMultiplier;

    public float guestID;

    public ClientType clientType;

    public Commande commande;

    public void Start()
    {

        commandesManager = CommandesManager.Instance;
        resourceManager = ResourceManager.Instance;

        int rng = UnityEngine.Random.Range(0, 1);
        if (rng == 0 )
        {
            clientType = ClientType.GARCON;
        }
        else
        {
            clientType = ClientType.FILLE;
        }

        waitingLine = GameObject.FindGameObjectWithTag("WaitingLine").gameObject;
        requestLine = GameObject.FindGameObjectWithTag("RequestingLine").gameObject;
        exitDoor = GameObject.FindGameObjectWithTag("ExitDoor").gameObject;

        guestID = (float)UnityEngine.Random.Range(0, 99999);
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

            if (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z) == 
                new Vector3(waitingLine.gameObject.transform.position.x, 0, waitingLine.gameObject.transform.position.z))
            {
                state = nextState;
            }
        }

        if (state == 1)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z), 
                                                                     new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, 0, requestLine.gameObject.transform.position.z), speed / 100);
            
            if (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z) ==
                new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, 0, requestLine.gameObject.transform.position.z))
            {
                this.gameObject.transform.rotation = waitingLine.gameObject.transform.rotation;

            }
            else
            {
                this.gameObject.transform.rotation = requestLine.gameObject.transform.rotation;
            }
            //la commande a été accepté
        }


        if (state == 2)
        {

            //wait avec la commande
        }

        if (state == 3)
        {
            //go table
            try
            {
                if (table.tag != "WaitingTable")
                {
                    this.gameObject.transform.rotation = table.gameObject.transform.rotation;
                    this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z),
                                                                         new Vector3(table.gameObject.transform.position.x, 0, table.gameObject.transform.position.z), speed / 100);
                }
                else
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z),
                                                                     new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, 0, requestLine.gameObject.transform.position.z), speed / 100);

                }
            }
            catch(UnassignedReferenceException) { }

        }

        if (state == 4)
        {
            if (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z) == 
                new Vector3(table.gameObject.transform.position.x, 0, table.gameObject.transform.position.z))
            {
                //SATISFACTION
                Debug.Log("Satisfaction");
                this.gameObject.transform.rotation = exitDoor.gameObject.transform.rotation;
            }
            
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z),
                                                                         new Vector3(exitDoor.gameObject.transform.position.x, 0, exitDoor.gameObject.transform.position.z), speed / 100);


            if (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z) == 
                new Vector3(exitDoor.gameObject.transform.position.x, 0, exitDoor.gameObject.transform.position.z))
            {
                Destroy(this.gameObject);
            }
        }
    }



    private void OnMouseUp()
    {
        if (state == 1)
            GetNewCommand();

        if (state == 2)
        {
            Commande _commande = GuestsManager.Instance.commandeToGive;

            bool regu = _commande.RegularCoffee >= commande.RegularCoffee;
            bool blond = _commande.BlondCoffee >= commande.BlondCoffee;
            bool deca = _commande.DecaCoffee >= commande.DecaCoffee;
            bool crois = _commande.Croissant >= commande.Croissant;
            bool muf = _commande.Muffin >= commande.Muffin;
            bool don = _commande.Donut >= commande.Donut;

            if (!regu || !blond || !deca || !crois || !muf || !don) satisfaction = 0.5f;



            GuestsManager.Instance.MakeNewCommandeToGive();
            state = 3;
        }
    }

    public CommandesManager commandesManager;
    public ResourceManager resourceManager;
    public float price = 0;


    private void GetNewCommand()
    {
        commandesManager.NewCommand(this);
        price = commandesManager.regularCoffeePrice * commandesManager.regularcoffee
            + commandesManager.decaCoffeePrice * commandesManager.decaCoffee
            + commandesManager.blondCoffeePrice * commandesManager.blondCoffee
            + commandesManager.donutPrice * commandesManager.donut
            + commandesManager.painAuChocolatPrice * commandesManager.painAuChocolat
            + commandesManager.croissantPrice * commandesManager.croissant;
        price = price * resourceManager.Reputation;
        resourceManager.Money += Mathf.CeilToInt(price);
    }
}
