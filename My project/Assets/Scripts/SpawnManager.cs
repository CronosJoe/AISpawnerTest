using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayCycle;

public class SpawnManager : MonoBehaviour
{
    //this script will be placed onto each spawner and will hold a list of the enemies it spawns as well as a list of enemies the spawner can spawn.

    //references
    public DayCycle dayCycleRef;
    [SerializeField] List<Enemy> currentEnemies = new List<Enemy>();
    [SerializeField] List<Enemy> spawnableEnemies = new List<Enemy>();
    List<Enemy> notSpawnableEnemies = new List<Enemy>();
    private float currentOddsMax;

    private void Start()
    {
        UpdateSpawnRates();
        SetOdds();
        SpawnEnemies();
    }
    public void UpdateSpawnRates() //doing some hard coding in here to get around handling specifics on each enemy ideally I would have handled it on each enemy but I wanted a spawn manager
    {
        switch (dayCycleRef.currentPeriod) 
        {
            case DayPeriod.Morning:
                for (int i = 0; i < spawnableEnemies.Count; i++)
                {
                    spawnableEnemies[i].changedSpawnRate = 0; //reset them each time it comes up this is in case we ever change more then once per run
                    if (spawnableEnemies[i].classes == Enemy.EnemyClasses.Archer)
                    {
                        spawnableEnemies[i].changedSpawnRate += Random.Range(0.2f, 0.4f);
                    }
                    if (spawnableEnemies[i].name == "BrownEnemy")
                    {
                        spawnableEnemies[i].changedSpawnRate -= Random.Range(0.1f, 0.3f);
                        //need to see if still spawnable
                        if (spawnableEnemies[i].spawnRate < 0f)
                        {
                            spawnableEnemies.RemoveAt(i);
                        }
                    }
                }
                break;
            case DayPeriod.Afternoon:
                for (int i = 0; i < spawnableEnemies.Count; i++)
                {
                    spawnableEnemies[i].changedSpawnRate = 0; //reset them each time it comes up this is in case we ever change more then once per run
                    if (spawnableEnemies[i].classes == Enemy.EnemyClasses.Assassin) 
                    {
                        spawnableEnemies[i].changedSpawnRate -= spawnableEnemies[i].defaultSpawnRate;
                        //need to remove from spawnables
                        spawnableEnemies.RemoveAt(i);
                    }
                    else 
                    {
                        spawnableEnemies[i].changedSpawnRate += Random.Range(-0.2f, 0.2f);
                        //need to see if still spawnable
                        if (spawnableEnemies[i].spawnRate < 0f) 
                        {
                            spawnableEnemies.RemoveAt(i);
                        }
                    }
                }
                break;
            case DayPeriod.Night:
                //no changes during night
                break;
        }
    }
    public void SetOdds() //set the oddsmax which will be the high end of our random value that we generate
    {
        for(int i = 0; i < spawnableEnemies.Count; i++) 
        {
            if (spawnableEnemies[i].spawnRate >= 0) 
            {
                currentOddsMax += spawnableEnemies[i].spawnRate;
            }
        }
    }
    public void SpawnEnemies() //this will go through the process of checking if the enemies that are available to spawn meet within the random range we set before spawning an enemy
    {
        float randomSpawn = Random.Range(0, currentOddsMax);
        float previousValue = 0f; //this will allow us to 
        for (int i = 0; i < spawnableEnemies.Count; i++)
        {
          //this takes the current spawnrate + the previous spawn rate to define a top end then takes the previous spawn rate as a bottom end, that way we don't double up
          if (randomSpawn <= spawnableEnemies[i].spawnRate + previousValue && randomSpawn > previousValue) 
          {     //if (random > current + previous && random < previous )
                Instantiate(spawnableEnemies[i], this.transform);
                currentEnemies.Add(spawnableEnemies[i]);
          }
            previousValue += spawnableEnemies[i].spawnRate;
        }
        if(currentEnemies.Count == 0) //this is for debugging purposes remove later
        {
            Debug.Log("The float generated weird nothing spawned");
        }
    }
}
