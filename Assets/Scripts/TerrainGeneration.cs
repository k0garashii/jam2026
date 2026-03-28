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
    private List<TerrainPrefabs> terrains = new List<TerrainPrefabs>();
    public int numLines = 6;
    public int numColumns = 6;
    
    public GameObject greenHotel;
    public GameObject redHotel;
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
                GameObject randGo =  terrains[i * numLines + j].GetRandomTile();
                //Position to modify
                Vector3 pos = new Vector3(j * 40, 0, -i * 30);
                Instantiate(randGo, pos, Quaternion.identity);
            }
        }
    }

    public void GenerateGreenHotel()
    {
        int line = Random.Range(0, 3);
        int column = Random.Range(0, 3);
        Vector3 position = new Vector3(-40 + column * 40, 0, line * 30);
        Instantiate(greenHotel, position, Quaternion.identity);
    }
    
    public void GenerateRedHotel()
    {
        int line = Random.Range(0, 3);
        int column = Random.Range(0, 3);
        Vector3 position = new Vector3(-40 + column * 40, 0, line * 30);
        Instantiate(redHotel, position, Quaternion.identity);
    }
}
