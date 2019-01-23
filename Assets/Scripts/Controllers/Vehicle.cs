using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * MARIA
 * 
 */

// BASE CLASS FOR ALL VEHICLES
public abstract class Vehicle : MonoBehaviour
{
    
    public float MaxSpeed { get; set; }
    public float MaxSteer { get; set; }
    public float Breaks { get; set; }
    public float Acceleration { get; set; }
    public float Steer { get; set; }
    public bool AccelFwd { get; set; }
    public bool AccelBwd { get; set; }

    public abstract void Accelerate(int Direction);

    public abstract void StopAcc(int Direction, float BreakinfFactor);

}
