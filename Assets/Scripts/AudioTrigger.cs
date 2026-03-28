using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioTrigger : MonoBehaviour
{
    public List<StudioEventEmitter> audioSource;
    private BiomeHandler biomeHandler;

    private void Awake()
    {
        biomeHandler = GetComponentInParent<BiomeHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < audioSource.Count; i++)
        {
            audioSource[i].Play();
            audioSource[i].AllowFadeout = true;
        }
        GameManager.instance.UpdatePlayerPosition(biomeHandler);
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < audioSource.Count; i++)
        {
            audioSource[i].Stop();
            Gamepad.current.SetMotorSpeeds(0.5f, 1f);
        }
    }
}
