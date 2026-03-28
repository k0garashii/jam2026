using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public List<GameObject> topLeft = new List<GameObject>();
    public List<GameObject> top = new List<GameObject>();
    public List<GameObject> topRight = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> center = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    public List<GameObject> bottomLeft = new List<GameObject>();
    public List<GameObject> bottom = new List<GameObject>();
    public List<GameObject> bottomRight = new List<GameObject>();
    void Start()
    {
        GenerateTerrain(topLeft, new Vector3(-40, 0, 60));
        GenerateTerrain(top, new Vector3(0, 0, 60));
        GenerateTerrain(topRight, new Vector3(40, 0, 60));
        GenerateTerrain(left, new Vector3(-40, 0, 30));
        GenerateTerrain(center, new Vector3(0, 0, 30));
        GenerateTerrain(right, new Vector3(40, 0, 30));
        GenerateTerrain(bottomLeft, new Vector3(-40, 0, 0));
        GenerateTerrain(bottom, new Vector3(0, 0, 0));
        GenerateTerrain(bottomRight, new Vector3(40, 0, 0));
    }
    
    void GenerateTerrain(List<GameObject> go, Vector3 position)
    {
        int rand = Random.Range(0, go.Count);
        Instantiate(go[rand], position, Quaternion.identity);
    }
}
