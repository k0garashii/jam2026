using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BiomeSoundPlayer : MonoBehaviour
{
    private EventInstance biomeInstance;
    private Rigidbody playerRigidbody;
    private string currentBiomeLabel;
    private string currentAnimalLabel;
    private bool hasInstance;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        CreateBiomeInstance();
        UpdateBiomeParameters();
    }

    private void Update()
    {
        UpdateBiomeParameters();
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

    private void UpdateBiomeParameters()
    {
        if (!hasInstance || GameManager.instance == null || GameManager.instance.CurrentBiome == null)
        {
            return;
        }

        BiomeHandler currentBiome = GameManager.instance.CurrentBiome;
        string biomeLabel = BiomeAudioLabels.GetBiomeLabel(currentBiome.biomeType);
        string animalLabel = BiomeAudioLabels.GetAnimalLabel(currentBiome.soundType);

        if (biomeLabel == currentBiomeLabel && animalLabel == currentAnimalLabel)
        {
            return;
        }

        currentBiomeLabel = biomeLabel;
        currentAnimalLabel = animalLabel;
        biomeInstance.setParameterByNameWithLabel("Biome", currentBiomeLabel);
        biomeInstance.setParameterByNameWithLabel("Animal", currentAnimalLabel);
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
        currentAnimalLabel = null;
    }
}
