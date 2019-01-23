using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{

    protected float _maxSpeed, _maxSteer, _breaks, _acceleration, _steer;
   
    protected bool _accelFwd, _accelBwd, _steerLeft, _steerRight;

    

    public float MaxSpeed { get; set; }
    public float MaxSteer { get; set; }
    public float Breaks { get; set; }
    public float Acceleration { get; set; }
    public float Steer { get; set; }
    public bool AccelFwd { get; set; }
    public bool AccelBwd { get; set; }
    public bool SteerLeft { get; set; }
    public bool SteerRight { get; set; }


    public abstract void Accel(int Direction);
    public abstract void StopAccel(int Direction, float BreakinfFactor);

}
