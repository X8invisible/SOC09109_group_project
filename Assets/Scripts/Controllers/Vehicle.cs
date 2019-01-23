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
    public Vehicle()
    {
        Debug.Log("Vehicle constructor called");
    }

    public float MaxSpeed { get; set; }


    public abstract void Accelerate();

    public abstract void StopAcc();


    /*

    protected float _maxSpeed, _maxSteer, _breaks, _acceleration, _steer;
    protected bool _accelFwd, _accelBwd;
    
    public float MaxSpeed { get; set; }
    public float MaxSteer { get; set; }
    public float Breaks { get; set; }
    public float Acceleration { get; set; }
    public float Steer { get; set; }
    public bool AccelFwd { get; set; }
    public bool AccelBwd { get; set; }

    public abstract void Accel(int Direction);
    public abstract void StopAccel(int Direction, float BreakinfFactor);
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            Acceleration = 0.0f;
    }

    */
}
