using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public EventReference SoundEffect;

    public void Start()
    {
        AudioPlayer.instance.PlayOneShot(SoundEffect, this.transform.position);
    }
}
