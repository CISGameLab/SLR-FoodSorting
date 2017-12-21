using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMan : MonoBehaviour {

    public AudioSource Sound;
    public AudioClip pointSoundClip;
    public AudioClip wrongSoundClip;
    public AudioClip dragSoundClip;
    public AudioClip clickSoundClip;

    public void PointSound()
    {
        Sound.clip = pointSoundClip;
        Sound.Play();
        //Sound.Play(44100);
    }

    public void WrongSound()
    {
        Sound.clip = wrongSoundClip;
        Sound.Play();
        //Sound.Play(44100);
    }

    public void DragSound()
    {
        Sound.clip = dragSoundClip;
        Sound.Play();
        //Sound.Play(44100);
    }

    public void ClickSound()
    {
        Sound.clip = clickSoundClip;
        Sound.Play();
        //Sound.Play(44100);
    }
}
