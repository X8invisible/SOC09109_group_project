using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // MARIA

    Car car;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");
        car = new Car(transform);
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")) //Accelerate forwards
        {
            car.Accelerate(1);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))  // rotate to the right
                car.RotateRight();

            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))   // rotate to the left
                car.RotateLeft();
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) //Accelerate backwards
        {
            car.Accelerate(-1);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))  // rotate to the right
                car.RotateRight();

            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))   // rotate to the left
                car.RotateLeft();
        }

        else if (Input.GetKey(KeyCode.Space))  // Brakes
            car.StopCarMotion();

        else // if no button pressed, stop car
            car.BrakeSlowly();
    }

    

    // SONAS
    // Detects contact between the car and fuel objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
            other.gameObject.SetActive(false);
    }

    // CAIO
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
            car.Collision();
    }

}