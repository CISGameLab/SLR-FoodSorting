using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMan : MonoBehaviour {

    public AudioSource Sound;
    public AudioClip pointSoundClip;

    public void PointSound()
    {
        Sound.clip = pointSoundClip;
        Sound.Play();
        Sound.Play(44100);
    }
}
