using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume;
    public float delay;
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
