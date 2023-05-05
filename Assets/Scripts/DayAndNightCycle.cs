using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    public float x;
    public void Update()
    {
        x -= Time.deltaTime;

        if(x < -0.1f && x > -0.2f)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnTimer>().StartTimer();
        }
    }
}
