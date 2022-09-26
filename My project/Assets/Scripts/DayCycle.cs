using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public enum DayPeriod //setting up the day period for when enemies pull their stat changes
    {
      Morning,
      Afternoon,
      Night
    }
    private void Start()
    {
        ChangeCurrentPeriod();
    }
    public DayPeriod currentPeriod = DayPeriod.Morning;
    public void ChangeCurrentPeriod() //change the DayPeriod based on random chance
    {
        //going to keep this super basic and just use Unity's random number generator
        float randFloat = Random.value; //this make a number from 0-1
        if (randFloat <= .33f)
        {
            currentPeriod = DayPeriod.Morning;
        }
        else if(randFloat <= .66f) //if greater than .33 and less than .66
        {
            currentPeriod = DayPeriod.Afternoon;
        }
        else //if above .66
        {
            currentPeriod = DayPeriod.Night;
        }
    }

}
