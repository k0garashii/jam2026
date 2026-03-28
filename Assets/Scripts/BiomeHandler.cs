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
    public SoundType soundType;
}
