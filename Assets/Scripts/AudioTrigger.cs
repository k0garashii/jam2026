using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private BiomeHandler biomeHandler;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        biomeHandler = GetComponentInParent<BiomeHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        // if(!audioSource.isPlaying)
        //     audioSource.Play();
        GameManager.instance.UpdatePlayerPosition(biomeHandler);
    }
}
