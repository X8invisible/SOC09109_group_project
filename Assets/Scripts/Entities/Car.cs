using UnityEngine;
using UnityEngine.UI;
using System;

public class Car : Vehicle
{
    bool AccForward, AccBackward, Left, Right = false;

    void Start()
    {
        Debug.Log("Car start ");

        this.MaxSpeed = 7.0f;
        this.MaxSteer = 2.0f;
        this.Brakes = 0.2f;
        this.Acceleration = 0.0f;
        this.Steer = 0.0f;
        this.FuelCount = 10000.0f;
        this.Lives = 20.0f;
        this.Accelerate(10);
    }


    // MOVEMENT LOGIC
    public override void Accelerate(int Direction)
    {
        // Debug.Log("----start Accelerate from Car.cs----");

        if (CheckFuel() == false || CheckLives() == false)
          return;

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
        //Debug.Log("----RotateLeft----");

        Left = true;
    }

    public override void RotateRight()
    {
        //Debug.Log("----RotateRight----");

        Right = true;
    }

    public override void StopRotate()
    {
      this.Steer = 0;
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

    // When the car collides with an object and it loses lives
    public override void Collision()
    {
      if (AccForward == true)
        this.Lives -= (float)(Math.Round((Acceleration) / 2, MidpointRounding.AwayFromZero) / 2)*2;
      if (AccBackward == true)
        this.Lives -= (float)((Math.Round((Acceleration) / 2, MidpointRounding.AwayFromZero) / 2) * -1)*2;

      this.Acceleration = 0.0f;

      Debug.Log("Lives: " + this.Lives);

      if (this.Lives < 0)
      {
        this.Lives = 0;
        Debug.Log("You are now dead!");
      }
    }

    // Checks if the player is dead
    public override bool CheckLives()
    {
        if (this.Lives <= 0)
            return false;
        return true;
    }

    // Checks if player has no fuel
    public override bool CheckFuel()
    {
        if (this.FuelCount <= 0)
            return false;
        return true;
    }

    public void UpdateFuelCount()
    {

        // If there is acceleration, decrease fuel
        if (AccForward == true)
            FuelCount -= 0.01f * Acceleration;
        if (AccBackward == true)
            FuelCount -= 0.01f * Acceleration * -1;
        /*if (fuelCount <= 0)
        {
            Acceleration = 0;
            Steer = 0;
        }*/


        // Debug.Log("Fuel count: " + FuelCount);
         //Debug.Log("Speed: " + Acceleration);
    }

    // Detects contact between the car and fuel objects
    // Author: Sonas
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
          if(this.FuelCount>95)
            this.FuelCount += (100-this.FuelCount);
          else
            this.FuelCount +=5;
          other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Health"))
        {
          if (this.Lives <=19)
            this.Lives += 1.0f;
          other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.CompareTag("Obstacle"))
          this.Collision();
    }

}
