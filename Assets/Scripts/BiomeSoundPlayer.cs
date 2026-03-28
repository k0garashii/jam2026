using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BiomeSoundPlayer : MonoBehaviour
{
    private EventInstance biomeInstance;
    private Rigidbody playerRigidbody;
    private string currentBiomeLabel;
    private bool hasInstance;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        CreateBiomeInstance();
        UpdateBiomeParameter();
    }

    private void Update()
    {
        UpdateBiomeParameter();
    }

    private void OnDisable()
    {
        ReleaseBiomeInstance();
    }

    private void OnDestroy()
    {
        ReleaseBiomeInstance();
    }

    private void CreateBiomeInstance()
    {
        if (hasInstance)
        {
            return;
        }

        biomeInstance = RuntimeManager.CreateInstance("event:/Biomes");
        if (playerRigidbody != null)
        {
            RuntimeManager.AttachInstanceToGameObject(biomeInstance, gameObject, playerRigidbody);
        }
        else
        {
            RuntimeManager.AttachInstanceToGameObject(biomeInstance, gameObject);
        }

        biomeInstance.start();
        hasInstance = true;
    }

    private void UpdateBiomeParameter()
    {
        if (!hasInstance || GameManager.instance == null || GameManager.instance.CurrentBiome == null)
        {
            return;
        }

        string biomeLabel = BiomeAudioLabels.GetBiomeLabel(GameManager.instance.CurrentBiome.biomeType);
        if (biomeLabel == currentBiomeLabel)
        {
            return;
        }

        currentBiomeLabel = biomeLabel;
        biomeInstance.setParameterByNameWithLabel("Biome", currentBiomeLabel);
    }

    private void ReleaseBiomeInstance()
    {
        if (!hasInstance)
        {
            return;
        }

        biomeInstance.stop(STOP_MODE.ALLOWFADEOUT);
        biomeInstance.release();
        hasInstance = false;
        currentBiomeLabel = null;
    }
}
