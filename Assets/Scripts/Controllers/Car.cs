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

    public override void Accelerate()
    {
        Debug.Log("Accelerate from Car.cs");
    }

    public override void StopAcc()
    {
        Debug.Log("StopAcc from Car.cs");
    }


    /*
    // Start is called before the first frame update
    void Start()
    {
        
        base.MaxSpeed = 7.0f;
        base.MaxSteer = 2.0f;
        base.Breaks = 0.2f;
        base.Acceleration = 0.0f;
        base.Steer = 0.0f;
        
        Debug.Log("Car class Start");
        
    }
    
    
    public override void Accel(int Direction)
    {


        


        if (Direction == 1) // forwards
        {
            AccelFwd = true;   // start acceleration

            if (Acceleration <= MaxSpeed) // if acceleration hasn't reached the maximum speed, keep accelerating
                Acceleration += 0.05f;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))   // rotate to the left
                transform.Rotate(Vector3.forward * Steer);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))  // rotate to the right
                transform.Rotate(Vector3.back * Steer);

        }
        else if (Direction == -1) // backwards
        {
            AccelBwd = true;  // start acceleration backwards

            if ((-1 * MaxSpeed) <= Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                Acceleration -= 0.05f;   // keep decelerating if MinSpeed hasn't been reached

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
                transform.Rotate(Vector3.back * Steer);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
                transform.Rotate(Vector3.forward * Steer);

        }

        if (Steer <= MaxSteer)
            Steer += 0.01f;

        // Move the transform of the car in the direction and distance of translation.
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);
        // vector2.up = vector(0,1) = move up


        


    }

    public override void StopAccel(int Direction, float BreakingFactor)
    {

        



        if (Direction == 1)  // stop accelerating forwards
        {
            if (Acceleration >= 0.0f)
            {
                Acceleration -= BreakingFactor;

                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.Rotate(Vector3.forward * Steer);
                if (Input.GetKey(KeyCode.RightArrow))
                    transform.Rotate(Vector3.back * Steer);
            }
            else
                AccelFwd = false;
        }
        else if (Direction == -1)  // stop accelerating backwards
        {
            if (Acceleration <= 0.0f)
            {
                Acceleration += BreakingFactor;

                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.Rotate(Vector3.back * Steer);
                if (Input.GetKey(KeyCode.RightArrow))
                    transform.Rotate(Vector3.forward * Steer);
            }
            else
                AccelBwd = false;
        }
        if (Steer >= 0.0f)
            Steer -= 0.01f;

        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);



        

    */
}

