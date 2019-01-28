using UnityEngine;
using UnityEngine.UI;

public class Car : Vehicle
{
    bool AccForward, AccBackward, Left, Right = false;

    private Transform transform;
    // Used for fuel counter
    public float fuelCount;

    public Car(Transform transform)
    {
        this.transform = transform; 
        this.MaxSpeed = 7.0f;
        this.MaxSteer = 2.0f;
        this.Brakes = 0.2f;
        this.Acceleration = 0.0f;
        this.Steer = 0.0f;
        this.fuelCount = 25.0f;
    }
    
    public override void Accelerate(int Direction)
    {
        // Debug.Log("----start Accelerate from Car.cs----");

        if (Direction == 1)
        {
            // Debug.Log("Direction == 1");

            AccForward = true;

            if (this.Acceleration <= this.MaxSpeed)
                this.Acceleration += 0.05f;

            if (Left)
            {
                transform.Rotate(Vector3.forward * Steer);
                Left = false;
            }
            else if (Right)
            {
                transform.Rotate(Vector3.back * Steer);
                Right = false;
            }
                
        }
        else if (Direction == -1)
        {
            // Debug.Log("Direction == -1");

            AccBackward = true;

            if ((-1 * this.MaxSpeed) <= this.Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                this.Acceleration -= 0.05f;   // keep decelerating if MinSpeed hasn't been reached

            if (Left)
            {
                transform.Rotate(Vector3.back * Steer);
                Left = false;
            }
            else if (Right)
            {
                transform.Rotate(Vector3.forward * Steer);
                Right = false;
            }
        }

        if (this.Steer <= this.MaxSteer)
            this.Steer += 0.01f;
        
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        // Debug.Log("----end of Accelerate in Car.cs----");
    }

    public override void StopAcc(int Direction, float BreakingFactor)
    {
        // Debug.Log("----start StopAcc in Car.cs----");

        if (Direction == 1) // stop accelerating forwards
        {
            if (this.Acceleration >= 0.0f)
            {
                this.Acceleration -= this.Brakes;

                if (Left)
                {
                    transform.Rotate(Vector3.forward * Steer);
                    Left = false;
                }
                if (Right)
                {
                    transform.Rotate(Vector3.back * Steer);
                    Right = false;
                }
            }
            else
                AccForward = false;
        }
        else if (Direction == -1)  // stop accelerating backwards
        {
            if (this.Acceleration <= 0.0f)
            {
                this.Acceleration += this.Brakes;

                if (Left)
                {
                    transform.Rotate(Vector3.back * Steer);
                    Left = false;
                }
                if (Right)
                {
                    transform.Rotate(Vector3.forward * Steer);
                    Right = false;
                }
            }
            else
                AccBackward = false;
        }
        if (this.Steer >= 0.0f)
            this.Steer -= 0.01f;

        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        // Debug.Log("----end StopACC in Car.cs----");
    }

    public override void RotateLeft()
    {
        Debug.Log("----RotateLeft----");

        Left = true;
    } 

    public override void RotateRight()
    {
        Debug.Log("----RotateRight----");

        Right = true;
    }

    // applies Brakes slowly if no key is pressed
    public override void BrakeSlowly()
    {
        // Debug.Log("----start of Brake----");

        if (AccForward) // while moving forwards
            StopAcc(1, 0.1f);

        else if (AccBackward) // while moving backwards
            StopAcc(-1, 0.1f);

        // Debug.Log("----end of Brake----");
    }

    // if space is pressed, stop car immediately
    public override void StopCarMotion()
    {
        Debug.Log("----start StopCarMotion----");

        if (AccForward)
            StopAcc(1, this.Brakes); // while moving forwards
        else if (AccBackward)
            StopAcc(-1, this.Brakes); // while moving backwards

        Debug.Log("----end StopCarMotion----");
    }

    // when the car collides with an object
    public override void Collision()
    {
        Debug.Log("----start collision----");

        this.Acceleration = 0.0f;

        Debug.Log("----end collision----");
    }

    //SONAS and ANDREI
    public void UpdateFuelCount( Image fuelBar, int maxFuel, int minFuel)
    {
        float currentFuelPercentage;
        // If there is acceleration, decrease fuel
        if (AccForward == true)
            FuelCount -= 0.01f * Acceleration;
        if (AccBackward == true)
            FuelCount -= 0.01f * Acceleration * -1;

        currentFuelPercentage = FuelCount / (maxFuel - minFuel);
        fuelBar.fillAmount = currentFuelPercentage;
        /*if (fuelCount <= 0)
      {
        Acceleration *= 0;
        Steer *= 0;
      }*/

        // this is to test to see if the fuel pick ups work
        Debug.Log("Fuel count: " + FuelCount);
    }

    public float FuelCount
    {
        get { return fuelCount; }
        set { fuelCount = value; }
    }
}

