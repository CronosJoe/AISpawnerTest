using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinEnemy : Enemy
{
    //here I'd implement any behavior that is specific to this class such as like a teleport or backstab type deal
    [SerializeField] int increasedSpeedRangeMin, increasedSpeedRangeMax; // putting this in so that a designer would be able to adjust this as they see fit, leaving private cause it isn't need elsewhere
    public override void UpdateStats(DayCycle currentDay) 
    {
        if (currentDay.currentPeriod == DayCycle.DayPeriod.Night)
        {
            changedSpeed += Random.Range(increasedSpeedRangeMin, increasedSpeedRangeMax); //This will return a float from 0-2 inclusive of each extreme
        }
    }
}
