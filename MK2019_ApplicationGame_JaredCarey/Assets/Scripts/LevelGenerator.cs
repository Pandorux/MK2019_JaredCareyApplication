using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Determines the maximum number of Terrain Sets that will be active in the scene at any given time.")]
    [Range(0, 100)]
    private int maxNumberOfTerrainSets;
    [SerializeField]
    GameObject[] terrainSets;
    [SerializeField]
    GameObject startingTerrainSet;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(true);
    }

    public void GenerateLevel(bool spawnStartSet) 
    {   
        Vector3 terrainEndPoint = Vector3.zero;
        GameObject terrainSet;

        for (int i = 0; i < maxNumberOfTerrainSets; i++) 
        {
            if (spawnStartSet) 
            {
                terrainSet = Instantiate(startingTerrainSet);
                terrainEndPoint = terrainSet.transform.GetChild(0).position;
                spawnStartSet = false;
            }
            else 
            {
                terrainSet = Instantiate(terrainSets[0], terrainEndPoint, Quaternion.identity);
                
                // if (terrainEndPoint != null)
                //     Debug.Log($"Terrain Set Spawned at {terrainEndPoint}.");

                terrainEndPoint = terrainSet.transform.GetChild(0).position;

            }
        }
    }
}
