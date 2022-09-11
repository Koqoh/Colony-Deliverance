using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBrain : MonoBehaviour
{
    public GameObject thrustTarget;
    AudioSource audioThing;
    void Start()
    {
        audioThing = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioThing.mute = !thrustTarget.GetComponent<Mover>().thrusting;
    }
}
