using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Assets
{
    public Texture2D beach;
    public Texture2D forest;
    public Texture2D mountain;
    public Texture2D river;
    public Texture2D blueShrine;
    public Texture2D redShrine;
    
    public Texture2D Owl;
    public Texture2D Wolf;
    public Texture2D Seagull;
    public Texture2D Dolphin;
    public Texture2D Frog;
    public Texture2D Duck;
    public Texture2D Bear;
    public Texture2D Eagle;
    public Texture2D Shrine;
}

public class GameManager : MonoBehaviour
{
    public PlayerController controller;
    public Assets assets;
    public List<RawImage> biomes = new List<RawImage>();
    public List<RawImage> sounds = new List<RawImage>();
    public Button mainScreenButton;
    
    public static GameManager instance { get; private set; }
    [HideInInspector] public List<BiomeHandler> chosenBiomes = new List<BiomeHandler>();
    public BiomeHandler CurrentBiome { get; private set; }
    private int currentBiomeIndex = 0;
    void Awake()
    {
        for(int i = 0; i < 36; i++)
        {
            chosenBiomes.Add(null);
        }
        if (!instance)
            instance = this;
        EventSystem.current.SetSelectedGameObject(mainScreenButton.gameObject);
    }

    public void SetMiniMap()
    {
        for(int i = 0; i < chosenBiomes.Count; i++)
        {
            if(chosenBiomes[i].biomeType == BiomeType.Beach)
                biomes[i].texture = assets.beach;
            else if (chosenBiomes[i].biomeType == BiomeType.Forest)
                biomes[i].texture = assets.forest;
            else if(chosenBiomes[i].biomeType == BiomeType.Mountain)
                biomes[i].texture = assets.mountain;
            else if(chosenBiomes[i].biomeType == BiomeType.River)
                biomes[i].texture = assets.river;
            else if(chosenBiomes[i].biomeType == BiomeType.BlueShrine)
                biomes[i].texture = assets.blueShrine;
            else if(chosenBiomes[i].biomeType == BiomeType.RedShrine)
                biomes[i].texture = assets.redShrine;
            
            if(chosenBiomes[i].soundType == AnimalType.Owl)
                sounds[i].texture = assets.Owl;
            else if(chosenBiomes[i].soundType == AnimalType.Wolf)
                sounds[i].texture = assets.Wolf;
            else if(chosenBiomes[i].soundType == AnimalType.Seagull)
                sounds[i].texture = assets.Seagull;
            else if(chosenBiomes[i].soundType == AnimalType.Dolphin)
                sounds[i].texture = assets.Dolphin;
            else if(chosenBiomes[i].soundType == AnimalType.Frog)
                sounds[i].texture = assets.Frog;
            else if(chosenBiomes[i].soundType == AnimalType.Duck)
                sounds[i].texture = assets.Duck;
            else if(chosenBiomes[i].soundType == AnimalType.Bear)
                sounds[i].texture = assets.Bear;
            else if(chosenBiomes[i].soundType == AnimalType.Eagle)
                sounds[i].texture = assets.Eagle;
            else if(chosenBiomes[i].soundType == AnimalType.Shrine)
                sounds[i].texture = assets.Shrine;
        }
    }

    public void UpdatePlayerPosition(BiomeHandler biomeHandler)
    {
        CurrentBiome = biomeHandler;
        biomes[currentBiomeIndex].color = new Color(1, 1, 1, 1f);
        currentBiomeIndex = biomeHandler.index;
        biomes[currentBiomeIndex].color = new Color(1, 1, 0, 1f);
    }

    public void Play()
    {
        controller.Activate();
    }
}
