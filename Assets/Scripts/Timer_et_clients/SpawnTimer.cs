using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool isDayNight;
    public bool HasStarted;
    // Start is called before the first frame update
    public void Start()
    {
        timerSpawned = Instantiate(timerPrefab, new Vector3(this.transform.parent.transform.position.x - 1.5f, 5, this.transform.parent.transform.position.z - 2.25f), Quaternion.Euler(45, 45, 0), this.gameObject.transform.parent.transform);
        aiguille = timerSpawned.transform.GetChild(0).gameObject;
        aiguille.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        timerSpawned.SetActive(false);
        timerColor = timerSpawned.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().material.color;
        HasStarted = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(timerTime > 0)
        {
            timerTime -= Time.deltaTime;

            aiguille.transform.localRotation = Quaternion.AngleAxis(timerTime * timerSpeed, Vector3.forward);
        }
        else
        {
            if(isDayNight && HasStarted)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void StartTimer()
    {
        HasStarted = true;
        timerSpeed = 360 / timerLenght;
        timerTime = timerLenght;
        timerSpawned.SetActive(true);

        if(timerTime <= timerLenght / 4)
        {
            timerColor.r += Time.deltaTime * timerSpeed;
        }
    }

    public void StopTimer()
    {
        timerSpawned.SetActive(false);
    }
}
