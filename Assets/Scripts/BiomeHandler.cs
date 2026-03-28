using UnityEngine;

public enum BiomeType
{
    Forest,
    Mountain,
    Beach,
    River,
    BlueShrine,
    RedShrine
}

public enum SoundType
{
    Owl,
    Wolf,
    Seagull,
    Dolphin,
    Frog,
    Duck,
    Bear,
    Eagle,
    Shrine
}

public class BiomeHandler : MonoBehaviour
{
    public BiomeType biomeType;
    [HideInInspector] public SoundType soundType;

    public void GenerateRandomSound()
    {
        int randomSound = Random.Range(0, 9);
        soundType = (SoundType)randomSound;
    }
}
