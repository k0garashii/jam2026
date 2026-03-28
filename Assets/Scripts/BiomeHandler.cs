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

public enum AnimalType
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
    [HideInInspector] public AnimalType soundType;
    [HideInInspector] public int index;

    public void Create(int listIndex)
    {
        GenerateRandomSound();
        index = listIndex;
    }
    private void GenerateRandomSound()
    {
        int randomSound = Random.Range(0, 9);
        soundType = (AnimalType)randomSound;
    }
}
