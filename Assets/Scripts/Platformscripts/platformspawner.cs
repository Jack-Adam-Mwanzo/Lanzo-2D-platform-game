using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikeplatformPrefab;
    public GameObject breakableplatform;

    public float platform_Spawn_Timer = 1.3f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;
    public float min_X = -1.4f, max_X = 1.4f;

    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;
         if(current_Platform_Spawn_Timer >= platform_Spawn_Timer){

             platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if(platform_Spawn_Count < 2) {
                newPlatform = Instantiate(platformPrefab,temp, Quaternion.identity);
            }else if(platform_Spawn_Count == 2){
                if(Random.Range(0, 2) > 0){
                     newPlatform = Instantiate(platformPrefab,temp, Quaternion.identity);
                }
            }else if(platform_Spawn_Count == 3){

                if(Random.Range(0, 2) > 0){
                     newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }else {
                    newPlatform = Instantiate(spikeplatformPrefab, temp, Quaternion.identity);
                }
            }else if(platform_Spawn_Count == 4){

                if(Random.Range(0, 2) > 0){
                     newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }else {
                    newPlatform = Instantiate(breakableplatform, temp, Quaternion.identity);
                }

                platform_Spawn_Count = 0;
            }
            if(newPlatform)
                newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;
     }
  }
}
