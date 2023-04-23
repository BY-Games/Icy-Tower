using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{

    [SerializeField] GameObject[] lvl1;
    [SerializeField] GameObject[] lvl2;
    [SerializeField] GameObject[] lvl3;


    [SerializeField] int platformCountToSwitch = 50; // Set to 50 for both level 1 and level 2
    [SerializeField] int platformCount = 100; // Set to 100 for both level 1 and level 2
    [SerializeField] float spawnDelay;

    private Vector3 spawnPosition = new Vector3(0, 0, 0);
    private int currentPlatformCount = 0;
    private int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnPlatforms());


    }


    private IEnumerator SpawnPlatforms()
    {
        bool spawnFirstPlatform = true;
        while (currentPlatformCount < platformCount)
        {
            Debug.Log("currentPlatformCount: " + currentPlatformCount + ",platformCount: " + platformCount);

            // Determine which level to use
            GameObject[] levelToUse;
            if (currentLevel == 1 || currentLevel == 2) // lvl 1 and lvl 2 have 50 platforms each
            {
                levelToUse = currentLevel == 1 ? lvl1 : lvl2;
            }
            else
            {
                levelToUse = lvl3;
            }


            // Determine which platform prefab to use
            int prefabIndex = 0; // Always start with the first platform in the level
            if (!spawnFirstPlatform)
            {
                prefabIndex = Random.Range(1, levelToUse.Length); // Choose a random platform prefab
            }

            // Spawn the platform
            GameObject platform = Instantiate(levelToUse[prefabIndex], spawnPosition, Quaternion.identity);

            // Update the spawn position and platform count
            spawnPosition.y += Random.Range(4f, 5f);
            spawnPosition.x = Random.Range(-7f, 7f);



            // Check if the platform is a level 3 platform and attach the MovingPlatform script if it is
            if (currentLevel == 3)
            {
                MovingPlatform movingPlatform = platform.GetComponent<MovingPlatform>();
                if (movingPlatform != null)
                {
                    // Set the start and end points for the moving platform
                    Transform startPoint = new GameObject("Start Point").transform;
                    startPoint.position = spawnPosition;
                    Transform endPoint = new GameObject("End Point").transform;
                    endPoint.position = new Vector3(spawnPosition.x * -7, spawnPosition.y, spawnPosition.z);
                    movingPlatform.startPoint = startPoint;
                    movingPlatform.endPoint = endPoint;


                    // note this make endless loop 
                    platformCount++;
                    currentPlatformCount--;
                }
            }

            if (currentLevel < 3)
            {
                currentPlatformCount++;
            }


            // Determine if we should switch to the next level
            if (currentLevel == 1 && currentPlatformCount == 49)
            {

                currentLevel++;
                spawnFirstPlatform = true; // Set flag to spawn the first platform in the new level
                platformCount = 100; // Set platform count to 50 for level 2
            }
            else if (currentLevel == 2 && currentPlatformCount == 99)
            {
                currentLevel++;
                spawnFirstPlatform = true; // Set flag to spawn the first platform in the new level
                platformCount = 150; // Set platform count to 50 for level 2

            }
            else
            {
                spawnFirstPlatform = false; // Set flag to spawn random platforms
            }

            yield return new WaitForSeconds(spawnDelay);
        }


    }




    //todo not work well 
    private void OnBecameInvisible()
    {
        // Check if the object is a platform
        if (gameObject.CompareTag("Ground"))
        {

            
            // Destroy the platform object
            Destroy(gameObject);
        }
    }
}







