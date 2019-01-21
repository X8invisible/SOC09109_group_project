using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES - appear in unity and can drag and drop objects into them
    public float MaxSpeed = 7.0f;
    public float MaxSteer = 2.0f;
    public float Breaks = 0.2f;


    // PRIVATE VARIABLES
    [SerializeField]  // force unity to also serialize private fields and not only public
    float Acceleration = 0.0f;
    float Steer = 0.0f;

    bool AccelFwd, AccelBwd;
    bool SteerLeft, SteerRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow)) //Accelerate forwards
            Accel(1);

        else if (Input.GetKey(KeyCode.DownArrow)) //Accelerate backwards
            Accel(-1);

        else
        {
            if (AccelFwd)  //Applies breaks slowly if no key is pressed while in forward direction
                StopAccel(1, 0.1f);

            else if (AccelBwd)    //Applies breaks slowly if no key is pressed while in backward direction
                StopAccel(-1, 0.1f);
        }

    }

    // Acceleration of the car
    public void Accel(int Direction)
    {
        if (Direction == 1) // forwards
        {
            AccelFwd = true;   // start acceleration

            if (Acceleration <= MaxSpeed) // if acceleration hasn't reached the maximum speed, keep accelerating
                Acceleration += 0.05f;

            if (Input.GetKey(KeyCode.LeftArrow))   // rotate to the left
                transform.Rotate(Vector3.forward * Steer);

            if (Input.GetKey(KeyCode.RightArrow))  // rotate to the right
                transform.Rotate(Vector3.back * Steer);

        }
        else if (Direction == -1) // backwards
        {
            AccelBwd = true;  // start acceleration backwards

            if ((-1 * MaxSpeed) <= Acceleration) // MinSpeed is MaxSpeed * -1 so they are symmetrical
                Acceleration -= 0.05f;   // keep decelerating if MinSpeed hasn't been reached

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.back * Steer);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.forward * Steer);

        }

        if (Steer <= MaxSteer)
            Steer += 0.01f;

        // Move the transform of the car in the direction and distance of translation.
        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);
        // vector2.up = vector(0,1) = move up

    }

    // stop acceleration of car
    public void StopAccel(int Direction, float BreakingFactor)
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

    }

    // Detects contact between the car and fuel objects
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Fuel"))
      {
        other.gameObject.SetActive(false);
      }
    }

}
