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
        if (biomeType == BiomeType.Forest)
        {
            int randomSound = Random.Range(0, 2);
            soundType = (AnimalType)randomSound;
        } else if (biomeType == BiomeType.Mountain)
        {
            int randomSound = Random.Range(2, 4);
            soundType = (AnimalType)randomSound;
        } else if (biomeType == BiomeType.Beach)
        {
            int randomSound = Random.Range(4, 6);
            soundType = (AnimalType)randomSound;
        } else if (biomeType == BiomeType.River)
        {
            int randomSound = Random.Range(6, 8);
            soundType = (AnimalType)randomSound;
        } else if (biomeType == BiomeType.BlueShrine || biomeType == BiomeType.RedShrine)
        {
            soundType = AnimalType.Shrine;
        }
    }
}
