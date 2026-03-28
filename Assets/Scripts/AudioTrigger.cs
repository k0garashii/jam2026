using System;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!audioSource.isPlaying)
            audioSource.Play();
    }
}
