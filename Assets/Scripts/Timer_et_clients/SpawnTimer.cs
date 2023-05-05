using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject timerPrefab;
    public GameObject timerSpawned;
    public GameObject aiguille;

    public float timerLenght;
    public float time;
    public float timerSpeed;
    public float timerTime;
    public Color timerColor;

    // Start is called before the first frame update
    public void Start()
    {
        timerSpawned = Instantiate(timerPrefab, new Vector3(this.transform.parent.transform.position.x - 1.5f, 5, this.transform.parent.transform.position.z - 2.25f), Quaternion.Euler(45, 45, 0), this.gameObject.transform.parent.transform);
        aiguille = timerSpawned.transform.GetChild(0).gameObject;
        timerSpawned.SetActive(false);
        timerColor = timerSpawned.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if(time > 0)
        {
            timerTime -= Time.deltaTime;
            time = timerLenght - timerTime;

            aiguille.transform.localRotation = Quaternion.Euler(0, 0, timerLenght * timerSpeed);
        }
    }

    public void StartTimer()
    {
        timerSpeed = aiguille.transform.rotation.z / timerLenght;
        timerTime = timerLenght;
        timerSpawned.SetActive(true);

        if(time <= timerLenght / 4)
        {
            timerColor.r += Time.deltaTime * timerSpeed;
        }
    }

    public void StopTimer()
    {
        timerSpawned.SetActive(false);
    }
}
