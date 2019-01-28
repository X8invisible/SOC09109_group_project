using UnityEngine;

public class Car : Vehicle
{
    bool AccForward, AccBackward, Left, Right;


    void Start()
    {
        Debug.Log("Car start ");

        this.MaxSpeed = 7.0f;
        this.MaxSpeed = 7.0f;
        this.MaxSteer = 2.0f;
        this.Brakes = 0.2f;
        this.Acceleration = 0.0f;
        this.Steer = 0.0f;
          
        
    }

    // ACCELERATION LOGIC
    
    public override void Accelerate(int Direction)
    {
        Debug.Log("----start Accelerate from Car.cs----");

        if (Direction == 1)
        {
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
            AccBackward = true;

            if ((-1 * this.MaxSpeed) <= this.Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                this.Acceleration -= 0.05f;   // keep decelerating if MinSpeed hasn't been reached

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

        if (this.Steer <= this.MaxSteer)
            this.Steer += 0.01f;

       // transform what?? how can I connect the car that the player uses with this movement?
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        Debug.Log("----end of Accelerate in Car.cs----");
    }

    public override void StopAcc(int Direction, float BreakingFactor)
    {
        Debug.Log("----start StopAcc in Car.cs----");

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


    // THIS NEEDS TWEAKING
    // applies Brakes slowly if no key is pressed
    public override void BrakeSlowly()
    {
        //Debug.Log("----start of Brake----");

        if (AccForward) // while moving forwards
            StopAcc(1, 0.1f);

        else if (AccBackward) // while moving backwards
            StopAcc(-1, 0.1f);

        //Debug.Log("----end of Brake----");
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


    // COLLISION LOGIC


    // when the car collides with an object
    public override void Collision()
    {
        Debug.Log("----start collision----");

        this.Acceleration = 0.0f;

        Debug.Log("----end collision----");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
            Acceleration = 0.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
            other.gameObject.SetActive(false);

    }

}

