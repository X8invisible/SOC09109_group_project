using UnityEngine;

public class Car : Vehicle
{
    bool AccForward, AccBackward, Left, Right;

    private Transform transform;

    Car car;

    public Car(Transform transform)
    {
        car = new Car(transform);
        //this.transform = transform;
        car.MaxSpeed = 7.0f;
        car.MaxSteer = 2.0f;
        car.Brakes = 0.2f;
        car.Acceleration = 0.0f;
        car.Steer = 0.0f;
    }
    
    public override void Accelerate(int Direction)
    {
        Debug.Log("----start Accelerate from Car.cs----");

        if (Direction == 1)
        {
            AccForward = true;

            if (car.Acceleration <= car.MaxSpeed)
                car.Acceleration += 0.05f;

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

            if ((-1 * car.MaxSpeed) <= car.Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                car.Acceleration -= 0.05f;   // keep decelerating if MinSpeed hasn't been reached

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

        if (car.Steer <= car.MaxSteer)
            car.Steer += 0.01f;

       // transform what?? how can I connect the car that the player uses with this movement?
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        Debug.Log("----end of Accelerate in Car.cs----");
    }

    public override void StopAcc(int Direction, float BreakingFactor)
    {
        Debug.Log("----start StopAcc in Car.cs----");

        if (Direction == 1) // stop accelerating forwards
        {
            if (car.Acceleration >= 0.0f)
            {
                car.Acceleration -= car.Brakes;

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
            if (car.Acceleration <= 0.0f)
            {
                car.Acceleration += car.Brakes;

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
        if (car.Steer >= 0.0f)
            car.Steer -= 0.01f;

        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        Debug.Log("----end StopACC in Car.cs----");
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
        Debug.Log("----start of Brake----");

        if (AccForward) // while moving forwards
            StopAcc(1, 0.1f);

        else if (AccBackward) // while moving backwards
            StopAcc(-1, 0.1f);

        Debug.Log("----end of Brake----");
    }

    // if space is pressed, stop car immediately
    public override void StopCarMotion()
    {
        Debug.Log("----start StopCarMotion----");

        if (AccForward)
            StopAcc(1, car.Brakes); // while moving forwards
        else if (AccBackward)
            StopAcc(-1, car.Brakes); // while moving backwards

        Debug.Log("----end StopCarMotion----");
    }

    // when the car collides with an object
    public override void Collision()
    {
        Debug.Log("----start collision----");

        car.Acceleration = 0.0f;

        Debug.Log("----end collision----");
    }

}

