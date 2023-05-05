using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuestBehaviour : MonoBehaviour
{
    public GameObject waitingLine;
    public GameObject requestLine;
    public GameObject table;
    public GameObject exitDoor;

    public GameObject talkEmote;
    public GameObject angryEmote;
    public GameObject unhappyEmote;
    public GameObject fineEmote;
    public GameObject happyEmote;
    public GameObject exclamationEmote;

    public float height;
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
    public float x;

    [Range (0.5f, 2f)]
    public float satisfaction;

    public int mealGeneration;
    public float mealComplexityMultiplier;
    public bool isThrowingATemperTentrum;

    public float guestID;

    public ClientType clientType;

    public Commande commande;

    public GameObject player;

    [SerializeField] private ParticleSystem buy;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

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

        talkEmote = this.gameObject.transform.GetChild(0).gameObject;
        angryEmote = this.gameObject.transform.GetChild(1).gameObject;
        unhappyEmote = this.gameObject.transform.GetChild(2).gameObject;
        fineEmote = this.gameObject.transform.GetChild(3).gameObject;
        happyEmote = this.gameObject.transform.GetChild(4).gameObject;
        exclamationEmote = this.gameObject.transform.GetChild(5).gameObject;

        anger = 0;

        guestID = (float)UnityEngine.Random.Range(0, 99999);
    }

    public void Update()
    {
        x -= Time.deltaTime;

        if (anger == 0) { ClearEmotes(); happyEmote.SetActive(true); }
        if (anger == 1) { ClearEmotes(); }
        if (anger == 2) { ClearEmotes(); fineEmote.SetActive(true); }
        if (anger == 3) { ClearEmotes(); happyEmote.SetActive(true); }

        timeSpentWaiting += Time.deltaTime;
        if (state == nextState)
        {
            x = 0;
            nextState = state + 1;
            timeSpentWaiting = 0;
            isThrowingATemperTentrum = false;
        }

        if (waitingTimeTolerance < timeSpentWaiting && isThrowingATemperTentrum == false)
        {
            anger += 1;
            isThrowingATemperTentrum = true;
        }
        if (waitingTimeTolerance > timeSpentWaiting)
        {
            angryEmote.SetActive(false);
        }
        else
        {
            angryEmote.SetActive(true);
        }

        if(state == 0)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z), 
                                                                     new Vector3(waitingLine.gameObject.transform.position.x - placeInLine * guestSpacing, height, waitingLine.gameObject.transform.position.z - placeInLine * guestSpacing * 0.33f), speed / 100);

            if (new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z) == 
                new Vector3(waitingLine.gameObject.transform.position.x, height, waitingLine.gameObject.transform.position.z))
            {
                state = nextState;
            }
            exclamationEmote.gameObject.SetActive(false);
        }

        if (state == 1)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z), 
                                                                     new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, height, requestLine.gameObject.transform.position.z), speed / 100);
            
            if (new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z) ==
                new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, height, requestLine.gameObject.transform.position.z))
            {
                this.gameObject.transform.rotation = waitingLine.gameObject.transform.rotation;

            }
            else
            {
                this.gameObject.transform.rotation = requestLine.gameObject.transform.rotation;
            }

            exclamationEmote.gameObject.SetActive(true);
            //la commande a été accepté
        }


        if (state == 2)
        {
            exclamationEmote.gameObject.SetActive(false);
            talkEmote.gameObject.SetActive(false);
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
                    this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                         new Vector3(table.gameObject.transform.position.x, height, table.gameObject.transform.position.z), speed / 100);
                }
                else
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                     new Vector3(requestLine.gameObject.transform.position.x - placeInLine * guestSpacing, height, requestLine.gameObject.transform.position.z), speed / 100);

                }

                if(x < -20)
                {
                    state = nextState;
                }

                if (x < -5)
                {
                    talkEmote.gameObject.SetActive(true);
                }
                else
                {
                    talkEmote.gameObject.SetActive(false);
                }
            }
            catch(UnassignedReferenceException) { }


        }

        if (state == 4)
        {
            talkEmote.gameObject.SetActive(false);

            if (new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z) == 
                new Vector3(table.gameObject.transform.position.x, height, table.gameObject.transform.position.z))
            {
                //SATISFACTION
                Debug.Log("Satisfaction");
                this.gameObject.transform.rotation = exitDoor.gameObject.transform.rotation;
            }
            
            this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                         new Vector3(exitDoor.gameObject.transform.position.x, height, exitDoor.gameObject.transform.position.z), speed / 100);


            if (new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z) == 
                new Vector3(exitDoor.gameObject.transform.position.x, height, exitDoor.gameObject.transform.position.z))
            {
                Destroy(this.gameObject);
            }
        }
    }



    bool madeACommande = false;

    private void OnMouseUp()
    {
        player.GetComponent<PlayerBehaviour>().ClearActions();
        player.GetComponent<PlayerBehaviour>().isGoingToClients = true;

        if (state == 1 && !madeACommande)
        {
            madeACommande = true;
            buy.Play();
            CommandesManager.Instance.NewCommand(this);
            state = 2;
            return;
        }

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
            Debug.Log($"Satisfaction = {satisfaction}");

            Destroy(etiquette);

            GuestsManager.Instance.MakeNewCommandeToGive();
            state = 3;
            return;
        }
    }
    public GameObject etiquette;

    private void ClearEmotes()
    {
        happyEmote.SetActive(false);
        angryEmote.SetActive(false);
        fineEmote.SetActive(false);
        happyEmote.SetActive(false);
    }
}
