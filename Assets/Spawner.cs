using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // seberapa banyak ingin di spawn
    public int numberToSpawn;
    // Tempat objek yang akan di spawn
    public List<GameObject> spawnPool;
    // memberikan batas spawnnya
    public GameObject spawner;


    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Spawn Objects
    public void SpawnObjects()
    {
        // Object yang ingin di spawn
        GameObject toSpawn;
        // index item random
        int randomItem = 0;
        // memberi batas di mesh collider
        MeshCollider c = spawner.GetComponent<MeshCollider>();

        // menaruh objek di scene
        float screenX, screenY;
        Vector2 pos;

        // loop for respawn
        for (int i = 0; i < numberToSpawn; i++)
        {
            // Random item from spawnpool
            randomItem = Random.Range(0, spawnPool.Count);
            // random item dari spawn pool
            toSpawn = spawnPool[randomItem];

            // Random position in ScreenX and ScreenY position 
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            // instantiate our objects and transform the position
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
