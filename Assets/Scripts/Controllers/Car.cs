using UnityEngine;

public class Car : Vehicle
{
    bool AccForward, AccelerateBackward;

    private Transform transform;

    public Car(Transform transform)
    {
        this.transform = transform;
    }
    

    
    public override void Accelerate(int Direction)
    {
        Debug.Log("----start Accelerate from Car.cs----");

        if (Direction == 1)
        {
            AccForward = true;

            if (Acceleration <= MaxSpeed)
                Acceleration += 0.05f;
        }

        if (Steer <= MaxSteer)
            Steer += 0.01f;

       // transform what?? how can I connect the car that the player uses with this movement?
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

        Debug.Log("----end of Accelerate in Car.cs----");
    }

    public override void StopAcc(int Direction, float BreakingFactor)
    {
        Debug.Log("----StopAcc in Car.cs----");
    }

    public override void RotateLeft()
    {
        Debug.Log("----RotateLeft in Car.cs----");
        // the next line causes an error
        this.transform.Rotate(Vector3.forward * Steer); 
        // Says this. is Null Reference
        Debug.Log("----END OF ROTATE LEFT----");
    }

    public override void RotateRight()
    {
        Debug.Log("----RotateRight in Car.cs----");
    }

}

