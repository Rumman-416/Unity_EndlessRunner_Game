using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public float zSpawn = 30;
    public float tileLength = 100;
    public int numberOfTiles = 4;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    void Start()
    {
       
        for(int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                spawnTile(0);
            else
                spawnTile(Random.Range(1, tileprefabs.Length));
        }
    }


    void Update()
    {
        if(playerTransform.position.z - 75 > zSpawn - (numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(1, tileprefabs.Length));
            DeleteTile();
        }
    }
        public void spawnTile (int tileIndex)
        {

        GameObject go = Instantiate(tileprefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;

        }
        
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
