using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    [SerializeField, Min(0.05f)] private float stepInterval = 0.45f;

    private const float MinMoveDistanceSqr = 0.0001f;

    private Vector3 lastPosition;
    private float stepTimer;
    private bool wasMoving;

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

        if (horizontalDelta.sqrMagnitude <= MinMoveDistanceSqr)
        {
            stepTimer = 0f;
            wasMoving = false;
            return;
        }

        if (GameManager.instance == null || GameManager.instance.CurrentBiome == null)
        {
            return;
        }

        if (!wasMoving)
        {
            wasMoving = true;
            PlayFootstep(GameManager.instance.CurrentBiome.biomeType);
            stepTimer = 0f;
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
        wasMoving = false;
    }

    private static void PlayFootstep(BiomeType biomeType)
    {
        EventInstance footstepInstance = RuntimeManager.CreateInstance("event:/Footsteps");
        footstepInstance.setParameterByNameWithLabel("Biome", BiomeAudioLabels.GetBiomeLabel(biomeType));
        footstepInstance.start();
        footstepInstance.release();
    }
}
