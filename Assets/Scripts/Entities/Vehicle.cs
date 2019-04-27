using UnityEngine;

// BASE CLASS FOR ALL VEHICLES
public abstract class Vehicle : MonoBehaviour
{
    public float MaxSpeed { get; set; }
    public float MaxSteer { get; set; }
    public float Brakes { get; set; }
    public float Acceleration { get; set; }
    public float Steer { get; set; }
    public float Lives { get; set; }
    public float FuelCount { get; set; }
    public float Score { get; set; }
    public float EngineHeat { get; set; }
    public bool AccelFwd { get; set; }
    public bool AccelBwd { get; set; }
    public bool Immunity { get; set; }


    public abstract void Accelerate(int Direction);

    public abstract void StopAcc(int Direction, float BreakingFactor);

    public abstract void RotateLeft();

    public abstract void RotateRight();

    public abstract void StopRotate();

    // apply brakes slowly if no key is pressed
    public abstract void BrakeSlowly();

    // stop car from moving
    public abstract void StopCarMotion();

    // when the car collides with something
    public abstract void Collision();

    // when a car loses its 3 lives - end of game
    public abstract bool CheckLives();

    public abstract bool CheckFuel();

    public abstract void UpdateScore();

    // When a car drives fast, the engine heats up
    public abstract void UpdateEngineHeat();

}