using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //this class would be inherited down the line
{
    public enum EnemyClasses //I'm using an Enum to define their type to remember + reference easier
    {
        Archer,
        Grunt,
        Assassin,
        None
    }
    //setting up the attributes
    [Header("Enemy Attributes")]
    public EnemyClasses classes = EnemyClasses.None; //This is so the enemy AI will know their own types for the day cycle etc
    [Header("Changed stats")]
    public int changedAttackPower = 0; //this will be used when the enemy checks the day cycle
    public int changedHealth = 0;
    public float changedSpeed = 0f;
    [Header("default stats")]
    public int defaultAttackPower = 0; //the default value which will be used in a get
    public int defaultHealth = 0;
    public float defaultSpeed = 0f;
    public int attackPower 
    {
        get { return changedAttackPower + defaultAttackPower; }
    }
    public int health 
    {
        get { return changedHealth + defaultHealth; }
    }
    public float speed //making speed a float because it would be used by whatever motor we have
    {
        get { return changedSpeed + defaultSpeed; }
    }
    public float defaultSpawnRate = 0f; //this will hold our default value to be changed
    public float changedSpawnRate = 0f; //changed spawn rate will be altered in our spawnmanager
    public float spawnRate
    {
        get { return defaultSpawnRate + changedSpawnRate; }
    }
    public virtual void UpdateStats(DayCycle currentDay) //this will pull from the day cycle to update this specific characters stats
    {

    }
}
