using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class PlayAudioTrigger : MonoBehaviour
{
    public EventReference SoundEffect;

    public void OnTriggerEnter(Collider other)
    {
        AudioPlayer.instance.PlayOneShot(SoundEffect, this.transform.position);
    } 
}
