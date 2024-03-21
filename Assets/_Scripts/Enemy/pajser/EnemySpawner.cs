using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public int repeatSpawnAfter;
    [HideInInspector] public List<GameObject> enemies;
    [HideInInspector] public List<Transform> locations; 
    public List<bool> reSpawn;
    


    // Start is called before the first frame update
    void Start()
    {
        if(enemies.Count != locations.Count)
            Debug.LogError("In:"+ this +": every location need corresponding enemy prefab!!!");

        if(repeatSpawnAfter != 0){
            InvokeRepeating("SpawnWave", 0 , repeatSpawnAfter);
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnWave(){
        for(int i = 0; i <= locations.Count -1; i++){
            Instantiate(enemies[i].gameObject, locations[i].position, locations[i].rotation, transform);
        }
    }

}
