using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    //here I'd implement any behavior that is specific to this class such as shooting etc
    public override void UpdateStats(DayCycle currentDay) //archers didn't get any changes based on time of day so I'm leaving this blank for now
    {
    }
}
