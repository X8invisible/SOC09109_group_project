using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // MARIA
    
    Vehicle car;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");

        car = new Car(transform);
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        // Accelerate forwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")){

            Debug.Log("----before car.Accelerate in PC----");

            car.Accelerate(1);

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
                car.RotateLeft();

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
                car.RotateRight();

            Debug.Log("----after car.Accelerate in PC----");
        }
        // Accelerate backwards
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            car.Accelerate(-1);

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
                car.RotateLeft();

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
                car.RotateRight();
        } 
        // Brakes
        else if (Input.GetKey(KeyCode.Space))
            car.StopCarMotion();
        // slow down car if no button is pressed until it stops
        else
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