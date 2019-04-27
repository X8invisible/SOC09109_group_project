using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class Car : Vehicle
{
    bool AccForward, AccBackward, Left, Right = false;


    void Start()
    {
        this.MaxSpeed = 7.0f;
        this.MaxSteer = 2.0f;
        this.Brakes = 0.2f;
        this.Acceleration = 0.0f;
        this.Steer = 0.0f;
        this.FuelCount = 100.0f;
        this.Lives = 20.0f;
        this.Score = 0.0f;
        this.EngineHeat = 0.0f;
        this.Immunity = false;
    }


    // MOVEMENT LOGIC
    public override void Accelerate(int Direction)
    {
        if (CheckFuel() == false || CheckLives() == false)
        {
          this.Acceleration = 0;
        }


        if (Direction == 1)
        {
            AccForward = true;

            if (this.Acceleration <= this.MaxSpeed)
                this.Acceleration += 0.1f;

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
            AccBackward = true;

            if ((-1 * this.MaxSpeed) <= this.Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                this.Acceleration -= 0.1f;   // keep decelerating if MinSpeed hasn't been reached

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
    }


    public override void StopAcc(int Direction, float BreakingFactor)
    {
        if (Direction == 1) // stop accelerating forwards
        {
            if (this.Acceleration >= 0.0f)
            {
                this.Acceleration -= BreakingFactor;

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
                this.Acceleration += BreakingFactor;

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
    }


    public override void RotateLeft()
    {
        Left = true;
    }


    public override void RotateRight()
    {
        Right = true;
    }


    public override void StopRotate()
    {
        this.Steer = 0;
    }


    // applies Brakes slowly if no key is pressed
    public override void BrakeSlowly()
    {
        //Debug.Log("----start of Brake----");

        if (AccForward)
        { // while moving forwards
            StopAcc(1, 0.1f);
        }

        else if (AccBackward)
        { // while moving
            StopAcc(-1, 0.1f);
        }
    }


    // if space is pressed, stop car immediately
    public override void StopCarMotion()
    {
        if (AccForward)
            StopAcc(1, this.Brakes); // while moving forwards

        else if (AccBackward)
            StopAcc(-1, this.Brakes); // while moving backwards
    }
    // When the car collides with an object and it loses lives
    public override void Collision()
    {
      if (this.Immunity == true)
        return;

      if (AccForward == true)
        this.Lives -= (float)(Math.Round((Acceleration) / 2, MidpointRounding.AwayFromZero) / 2);

      if (AccBackward == true)
        this.Lives -= (float)((Math.Round((Acceleration) / 2, MidpointRounding.AwayFromZero) / 2) * -1);

        this.Acceleration -= 1.0f;

      if (this.Lives < 0)
        this.Lives = 0;

      StartCoroutine(ImmunityCounter(3));
    }

    // makes the car immune for a specified number of seconds
    IEnumerator ImmunityCounter(int seconds)
    {
      this.Immunity = true;

      yield return new WaitForSeconds(seconds);

      this.Immunity = false;
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


    // Updates the fuel counter as the car drives
    // Author: Sonas
    public void UpdateFuelCount()
    {
        // If there is acceleration, decrease fuel
        if (Acceleration > 0)
            FuelCount -= 0.01f * Acceleration;

        else
            FuelCount -= 0.01f * Acceleration * -1;
    }


    // Updates the score counter as the car drives
    // Author: Sonas
    public override void UpdateScore()
    {
      if (AccForward == true)
          Score += 0.01f * Acceleration;

      if (AccBackward == true)
          Score += 0.01f * Acceleration * -1;
    }


    // Updates the heat of the engine based on the speed of
    // the car
    // Author: Sonas
    public override void UpdateEngineHeat()
    {
      float maxHeat = 500.0f;

      if (Acceleration > 6 && this.EngineHeat < maxHeat)
        this.EngineHeat += 0.1f;

      if (Acceleration < 6 && this.EngineHeat > 0)
        this.EngineHeat -= 0.3f;

      else if (Acceleration < 2 && this.EngineHeat > 0)
        this.EngineHeat -= 2.0f;

      if (this.EngineHeat > 450)
      {
        if (this.Acceleration > 5)
          this.Acceleration = 5;

        this.MaxSpeed = 5.0f;
      }

      else if (this.MaxSpeed < 7 && this.EngineHeat < 300)
      {
        this.MaxSpeed = 7.0f;
      }
    }


    // Detects contact between the car and fuel objects
    // Author: Sonas
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
          if(this.FuelCount > 95)
            this.FuelCount += (100 - this.FuelCount);

          else
            this.FuelCount += 5;

          other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Health"))
        {
          if (this.Lives <= 19)
            this.Lives += 1.0f;

          other.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(15);

        other.gameObject.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("NPC"))
        this.Collision();
    }
}
