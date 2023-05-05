using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject door;
    public GameObject coffeeMachine;
    public GameObject pastry;
    public GameObject clients;

    public bool isGoingToStorage;
    public bool isGoingToCoffeeMachine;
    public bool isGoingToPastries;
    public bool isGoingToClients;

    public float height;
    public float offsetSpacing;
    public float speed;

    public void Update()
    {
        if (isGoingToStorage)
        {
            GoToStorage();
        }

        if(isGoingToCoffeeMachine)
        {
            GoToCoffeeMachine();
        }

        if (isGoingToPastries)
        {
            GoToPastries();
        }

        if (isGoingToClients)
        {
            GoToClients();
        }
    }

    public void GoToStorage()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                 new Vector3(door.gameObject.transform.position.x - offsetSpacing, height, door.gameObject.transform.position.z), speed / 100);

    }

    public void GoToCoffeeMachine()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                 new Vector3(coffeeMachine.gameObject.transform.position.x, height, coffeeMachine.gameObject.transform.position.z - offsetSpacing), speed / 100);
    }

    public void GoToPastries()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                 new Vector3(pastry.gameObject.transform.position.x, height, pastry.gameObject.transform.position.z + offsetSpacing), speed / 100);
    }

    public void GoToClients()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(new Vector3(this.gameObject.transform.position.x, height, this.gameObject.transform.position.z),
                                                                 new Vector3(clients.gameObject.transform.position.x, height, clients.gameObject.transform.position.z + offsetSpacing), speed / 100);
    }

    public void ClearActions()
    {
        isGoingToStorage = false;
        isGoingToCoffeeMachine= false;
        isGoingToPastries = false;
        isGoingToClients = false;
    }
}
