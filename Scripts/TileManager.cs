using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;

    private float spawnZ = -10.0f;

    private float tileLength = 10.0f;

    private int amountOfTiles = 4;

    private int lastPrefabIndex = 0;
    private int lastIndex = 0;


    // Use this for initialization
    private void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i<amountOfTiles; i++)
        {
            if (i<3)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update ()
    {
        if(playerTransform.position.z >spawnZ-amountOfTiles*tileLength)
        {
            SpawnTile();
        }
	
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        int index = RandomPrefabIndex();
        GameObject go;
        if (prefabIndex == -1)
        {
            if (index == 5)
            {
                if (lastIndex == 6)
                {
                    lastIndex = index;
                    go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
                    go.transform.SetParent(transform);
                    go.transform.position = Vector3.forward * spawnZ;
                    spawnZ += tileLength;
                }
                else
                    {
                    lastIndex = index;
                    go = Instantiate(tilePrefabs[index]) as GameObject;
                    go.transform.SetParent(transform);
                    go.transform.position = Vector3.forward * spawnZ + Vector3.left * 1.0f;
                    spawnZ += tileLength;
                }
            }
            else if (index == 6)
            {
                if (lastIndex == 5)
                {
                    lastIndex = index;
                    go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
                    go.transform.SetParent(transform);
                    go.transform.position = Vector3.forward * spawnZ;
                    spawnZ += tileLength;
                }
                else
                {
                    lastIndex = index;
                    go = Instantiate(tilePrefabs[index]) as GameObject;
                    go.transform.SetParent(transform);
                    go.transform.position = Vector3.forward * spawnZ + Vector3.right * 1.0f;
                    spawnZ += tileLength;
                }
            }
            else
            {
                lastIndex = index;
                go = Instantiate(tilePrefabs[index]) as GameObject;
                go.transform.SetParent(transform);
                go.transform.position = Vector3.forward * spawnZ;
                spawnZ += tileLength;
            }
        }
        else
        {
            lastIndex = index;
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
        }
        
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <=1)
        {
            return 0;
        }

        int RandomIndex = lastPrefabIndex;
        while(RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(1, tilePrefabs.Length);
        }
        lastPrefabIndex = RandomIndex;
        return RandomIndex;

    }

}
