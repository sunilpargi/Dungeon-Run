using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    private Transform playerTransform;
    private float spawnZ = -10f;
    private float tileLength = 10.0f;
    private float safeZone = 20.0f;
    private int amnTilesOnScreen = 7;
    private int lastPrefab = 0;

    private List<GameObject> activeList;
    void Start()
    {
        activeList = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            if(i < 3)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
          
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();

            DestroyTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        
        GameObject go;

        if(prefabIndex == -1)
        {
          go = Instantiate(tiles[RandomPrefabIndex()]) as GameObject;

        }
        else
        {
            go = Instantiate(tiles[0]) as GameObject;
           
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeList.Add(go);
    }

    private void DestroyTile()
    {
        Destroy(activeList[0]);
        activeList.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tiles.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefab;
        while (randomIndex == lastPrefab)
        {
            randomIndex = UnityEngine.Random.Range(0, tiles.Length);
        }

        lastPrefab = randomIndex;
        return randomIndex;
    }
}
