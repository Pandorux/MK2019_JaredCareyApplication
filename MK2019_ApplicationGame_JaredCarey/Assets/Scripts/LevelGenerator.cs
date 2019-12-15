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
        maxNumberOfTerrainSets = terrainSets.Length < maxNumberOfTerrainSets ?
            terrainSets.Length : maxNumberOfTerrainSets;

        SetupObjectPool();
        GenerateLevel(true);
    }

    void SetupObjectPool()
    {
        for(int i = 0; i < terrainSets.Length; i++)
        {
            terrainSets[i] = Instantiate(terrainSets[i]);
            terrainSets[i].SetActive(false);
        }
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
            other.gameObject.SetActive(false);
            
            if(other.gameObject.GetComponent<TerrainSet>())
            {
                foreach(Pickup pickup in other.gameObject.GetComponent<TerrainSet>().pickups)
                {
                    pickup.Reset();
                }
            }

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
            #if UNITY_EDITOR
                terrainSet.name = NameTerrainSet(terrainSet.name);
                Debug.Log($"Spawned {terrainSet.name}");
            #endif
        }
    }

    // TODO: This will become an infinite loop if all terrain sets are active
    void AddRandomTerrainSet()
    {
        int rand = Random.Range(0, terrainSets.Length);
        GameObject terrainSet = terrainSets[rand];

        if(!(terrainSet.active))
        {
            terrainSet.transform.position = terrainEndPoint;
            terrainSet.SetActive(true);
            terrainEndPoint = terrainSet.transform.GetChild(0).position;

            // Simplifies debugging the level generator
            #if UNITY_EDITOR
                //terrainSet.name = NameTerrainSet(terrainSet.name);
                Debug.Log($"Spawned {terrainSet.name}");
            #endif
        }
        else 
        {
            AddRandomTerrainSet();
        }

    }

    protected string NameTerrainSet(string terrainSetName)
    {
        totalSpawnedTerrainSets++;
        terrainSetName = $"TS_{totalSpawnedTerrainSets} - {terrainSetName}";
        return terrainSetName;
    }
}
