using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{

    [SerializeField] GameObject[] prefabsToSpawn;


    [SerializeField] int platformCountToSwitch;
    [SerializeField] int platformCount;
    [SerializeField] float spawnDelay;
    private bool shouldSpawnType3Platforms = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatforms());


    }

    IEnumerator SpawnPlatforms()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.x = Random.Range(-7f, 7f);
            spawnPosition.y += Random.Range(4f, 5f);

            if (i % 3 == 0)
            {
                Instantiate(prefabsToSpawn[0], spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(prefabsToSpawn[1], spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnDelay);

            if (i == platformCountToSwitch)
            {
                shouldSpawnType3Platforms = true;
            }
        }

        // Start spawning type 3 platforms after reaching platformCountToSwitch
        if (shouldSpawnType3Platforms)
        {
            while (true)
            {
                spawnPosition.x = Random.Range(-7f, 7f);
                spawnPosition.y += Random.Range(8f, 5f);
                Instantiate(prefabsToSpawn[3], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(prefabsToSpawn[0]);
        Destroy(prefabsToSpawn[1]);
      //  Destroy(prefabsToSpawn[]);
        
    }
}
