using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    [SerializeField, Min(0.05f)] private float stepInterval = 0.45f;
    [SerializeField, Min(0f)] private float minimumMoveSpeed = 0.1f;

    private Vector3 lastPosition;
    private float stepTimer;

    private void OnEnable()
    {
        ResetFootsteps();
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 horizontalDelta = currentPosition - lastPosition;
        horizontalDelta.y = 0f;
        lastPosition = currentPosition;

        float moveSpeed = horizontalDelta.magnitude / Time.fixedDeltaTime;
        if (moveSpeed < minimumMoveSpeed)
        {
            stepTimer = 0f;
            return;
        }

        if (GameManager.instance == null || GameManager.instance.CurrentBiome == null)
        {
            return;
        }

        stepTimer += Time.fixedDeltaTime;
        if (stepTimer < stepInterval)
        {
            return;
        }

        stepTimer = 0f;
        PlayFootstep(GameManager.instance.CurrentBiome.biomeType);
    }

    public void ResetFootsteps()
    {
        lastPosition = transform.position;
        stepTimer = 0f;
    }

    private static void PlayFootstep(BiomeType biomeType)
    {
        EventInstance footstepInstance = RuntimeManager.CreateInstance("event:/Footsteps");
        footstepInstance.setParameterByNameWithLabel("Biome", GetBiomeLabel(biomeType));
        footstepInstance.start();
        footstepInstance.release();
    }

    private static string GetBiomeLabel(BiomeType biomeType)
    {
        switch (biomeType)
        {
            case BiomeType.Forest:
                return "Forest";
            case BiomeType.Beach:
                return "Beach";
            case BiomeType.Mountain:
            case BiomeType.BlueShrine:
            case BiomeType.RedShrine:
                return "Mountain";
            case BiomeType.River:
                return "Lake";
            default:
                return "Forest";
        }
    }
}
