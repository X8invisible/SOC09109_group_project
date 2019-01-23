using UnityEngine;

// BASE CLASS FOR ALL VEHICLES
public abstract class Vehicle : MonoBehaviour
{
    public float MaxSpeed { get; set; }
    public float MaxSteer { get; set; }
    public float Brakes { get; set; }
    public float Acceleration { get; set; }
    public float Steer { get; set; }
    public bool AccelFwd { get; set; }
    public bool AccelBwd { get; set; }

    public abstract void Accelerate(int Direction);

    public abstract void StopAcc(int Direction, float BreakinfFactor);

    public abstract void RotateLeft();

    public abstract void RotateRight();

}
