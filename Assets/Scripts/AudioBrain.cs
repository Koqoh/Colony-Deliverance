using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBrain : MonoBehaviour
{
    AudioSource audioThing;
    void Start()
    {
        audioThing = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioThing.volume = ShipThrust.power * 0.05f;
    }
}
