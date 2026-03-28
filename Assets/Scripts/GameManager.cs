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
    
    private TerrainGeneration terrain;
    void Awake()
    {
        terrain = GetComponent<TerrainGeneration>();
        if (!instance)
            instance = this;
        EventSystem.current.SetSelectedGameObject(mainScreenButton.gameObject);
    }
    void Start()
    {
        controller.enabled = false;
        terrain.GenerateGreenHotel();
    }

    public void ShowMiniMap()
    {
        for(int i = 0; i < terrain.chosenBiomes.Count; i++)
        {
            if(terrain.chosenBiomes[i].biomeType == BiomeType.Beach)
                biomes[i].texture = assets.beach;
            else if (terrain.chosenBiomes[i].biomeType == BiomeType.Forest)
            {
                biomes[i].texture = assets.forest;
            }
            else if(terrain.chosenBiomes[i].biomeType == BiomeType.Mountain)
                biomes[i].texture = assets.mountain;
            else if(terrain.chosenBiomes[i].biomeType == BiomeType.River)
                biomes[i].texture = assets.river;
            else if(terrain.chosenBiomes[i].biomeType == BiomeType.BlueShrine)
                biomes[i].texture = assets.blueShrine;
            else if(terrain.chosenBiomes[i].biomeType == BiomeType.RedShrine)
                biomes[i].texture = assets.redShrine;
            
            if(terrain.chosenBiomes[i].soundType == SoundType.Owl)
                sounds[i].texture = assets.Owl;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Wolf)
                sounds[i].texture = assets.Wolf;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Seagull)
                sounds[i].texture = assets.Seagull;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Dolphin)
                sounds[i].texture = assets.Dolphin;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Frog)
                sounds[i].texture = assets.Frog;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Duck)
                sounds[i].texture = assets.Duck;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Bear)
                sounds[i].texture = assets.Bear;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Eagle)
                sounds[i].texture = assets.Eagle;
            else if(terrain.chosenBiomes[i].soundType == SoundType.Shrine)
                sounds[i].texture = assets.Shrine;
        }
    }

    public void Play()
    {
        controller.enabled = true;
    }
}
