using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * MARIA
 * 
 */

public class Car : Vehicle
{

    public override void Accelerate(int Direction)
    {
        Debug.Log("Accelerate from Car.cs");
        
    }

    public override void StopAcc(int Direction, float BreakingFactor)
    {
        Debug.Log("StopAcc from Car.cs");
    }

    
}

