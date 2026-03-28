using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainPrefabs
{
    public List<GameObject> tiles;

    public GameObject GetRandomTile()
    {
        int rand = Random.Range(0, tiles.Count);
        return tiles[rand];
    }
}
public class TerrainGeneration : MonoBehaviour
{
    public TerrainPrefabs topLeft;
    public TerrainPrefabs top;
    public TerrainPrefabs topRight;
    public TerrainPrefabs left;
    public TerrainPrefabs center;
    public TerrainPrefabs right;
    public TerrainPrefabs bottomLeft;
    public TerrainPrefabs bottom;
    public TerrainPrefabs bottomRight;
    //The first item of the list is the top left terrain. It goes from left to right, the from top to bottom.
    public int numLines = 6;
    public int numColumns = 6;
    public int tileWidth = 40;
    public int tileHeight = 30;
    public GameObject greenHotel;
    public GameObject redHotel;
    
    private List<TerrainPrefabs> terrains = new List<TerrainPrefabs>();
    [HideInInspector] public List<BiomeHandler> chosenBiomes = new List<BiomeHandler>();
    void Start()
    {
        SortTerrains();
        GenerateTerrain();
    }

    private void SortTerrains()
    {
        for(int i = 0; i < numLines; i++)
        {
            for(int j = 0; j < numColumns; j++)
            {
                if (i == 0 && j == 0)
                    terrains.Add(topLeft);
                else if (i == 0 && j == numColumns - 1)
                    terrains.Add(topRight);
                else if (i == numLines - 1 && j == 0)
                    terrains.Add(bottomLeft);
                else if (i == numLines - 1 && j == numColumns - 1)
                    terrains.Add(bottomRight);
                else if (i == 0)
                    terrains.Add(top);
                else if (i == numLines - 1)
                    terrains.Add(bottom);
                else if (j == 0)
                    terrains.Add(left);
                else if (j == numColumns - 1)
                    terrains.Add(right);
                else
                    terrains.Add(center);
            }
        }
    }
    
    private void GenerateTerrain()
    {
        for (int i = 0; i < numLines; i++)
        {
            for (int j = 0; j < numColumns; j++)
            {
                Vector3 pos = new Vector3(j * tileWidth, 0, -i * tileHeight);
                GameObject randGo = Instantiate(terrains[i * numLines + j].GetRandomTile(), pos, Quaternion.identity);
                BiomeHandler biomeHandler = randGo.GetComponent<BiomeHandler>();
                biomeHandler.GenerateRandomSound();
                chosenBiomes.Add(biomeHandler);
            }
        }
    }

    public void GenerateGreenHotel()
    {
        int line = Random.Range(0, numLines);
        int column = Random.Range(0, numColumns);
        Vector3 position = new Vector3(column * 40, 0, -line * 30);
        Instantiate(greenHotel, position, Quaternion.identity);
    }
    
    public void GenerateRedHotel()
    {
        int line = Random.Range(0, numLines);
        int column = Random.Range(0, numColumns);
        Vector3 position = new Vector3(column * 40, 0, -line * 30);
        Instantiate(redHotel, position, Quaternion.identity);
    }
}
