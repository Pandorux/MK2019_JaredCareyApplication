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

    Vector3 terrainEndPoint = Vector3.zero;

    int totalSpawnedTerrainSets;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(true);
    }

    void GenerateLevel(bool spawnStartSet) 
    {   
        GameObject terrainSet;

        for (int i = 0; i < maxNumberOfTerrainSets; i++) 
        {
            if (spawnStartSet) 
            {
                AddTerrainSet(startingTerrainSet);
                spawnStartSet = false;
            }
            else 
            {   
                AddRandomTerrainSet();
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"{other.gameObject.name} entered level gen collider");

        if(other.gameObject.tag == "TerrainSet")
        {
            Debug.Log("Destroying Terrain Set");
            Destroy(other.gameObject);
            AddRandomTerrainSet();
        }
    }

    void AddTerrainSet(GameObject terrainSet)
    {
        if(terrainSet)
        {
            terrainSet = Instantiate(terrainSet, terrainEndPoint, Quaternion.identity);
            terrainEndPoint = terrainSet.transform.GetChild(0).position;

            // Simplifies debugging the level generator
            // #if UNITY_EDITOR
            //     terrainSet.name = NameTerrainSet(terrainSet.name);
            //     Debug.Log($"Spawned {terrainSet.name}");
            // #endif
        }
    }

    void AddRandomTerrainSet()
    {
        GameObject terrainSet = Instantiate(terrainSets[Random.Range(0, terrainSets.Length)], terrainEndPoint, Quaternion.identity);
        
        // if (terrainEndPoint != null)
        //     Debug.Log($"Terrain Set Spawned at {terrainEndPoint}.");

        terrainEndPoint = terrainSet.transform.GetChild(0).position;

        // Simplifies debugging the level generator
        // #if UNITY_EDITOR
        //     terrainSet.name = NameTerrainSet(terrainSet.name);
        //     Debug.Log($"Spawned {terrainSet.name}");
        // #endif
    }

    protected string NameTerrainSet(string terrainSetName)
    {
        totalSpawnedTerrainSets++;
        terrainSetName = $"TS_{totalSpawnedTerrainSets} - {terrainSetName}";
        return terrainSetName;
    }
}
