using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntEnemy : Enemy
{
    //here I'd implement any behavior that is specific to this class
    public override void UpdateStats(DayCycle currentDay) //this will pull from the day cycle to update this specific characters stats for while in stage which is everything but spawn rate
    {
        if(currentDay.currentPeriod == DayCycle.DayPeriod.Afternoon) 
        {
            changedAttackPower = 1; //during the afternoon grunts gain +1 attack power
        }
    }
}
