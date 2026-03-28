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
    public GameObject blueHotel;
    public GameObject redHotel;
    
    private List<TerrainPrefabs> terrains = new List<TerrainPrefabs>();
    void Start()
    {
        GenerateHotel(blueHotel);
        GenerateHotel(redHotel);
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
                int index = i * numLines + j;
                if(GameManager.instance.chosenBiomes[index])
                    continue;
                Vector3 pos = new Vector3(j * tileWidth, 0, -i * tileHeight);
                GameObject randGo = Instantiate(terrains[index].GetRandomTile(), pos, Quaternion.identity);
                BiomeHandler biomeHandler = randGo.GetComponent<BiomeHandler>();
                biomeHandler.Create(index);
                GameManager.instance.chosenBiomes[index] = biomeHandler;
            }
        }
    }
    
    private void GenerateHotel(GameObject hotel)
    {
        bool validPosition = false;
        int line = 0;
        int column = 0;
        int index = 0;
        while (!validPosition)
        {
            line = Random.Range(1, numLines - 1);
            column = Random.Range(1, numColumns - 1);
            index = line * numLines + column;
            Debug.Log(index);
            if(!GameManager.instance.chosenBiomes[index])
                validPosition = true;
        }
        Vector3 position = new Vector3(column * tileWidth, 0, -line * tileHeight);
        GameObject randGo = Instantiate(hotel, position, Quaternion.identity);
        BiomeHandler biomeHandler = randGo.GetComponent<BiomeHandler>();
        biomeHandler.Create(index);
        GameManager.instance.chosenBiomes[index] = biomeHandler;
    }
}
