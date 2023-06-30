using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathNoiseController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip deathNoise;

    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = deathNoise;
    }
    public void PlayDeathNoise()
    {
        audiosource.Play();
        Debug.Log("death noise should be played");
    }
}
