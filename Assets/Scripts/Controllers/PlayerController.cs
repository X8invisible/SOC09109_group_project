using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Car car;
    
    //used for the HUD fuel representation
    public Image fuelBar;
    public int minFuel;
    public int maxFuel;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");
        car = new Car(transform);
        Debug.Log("hit");
    }
    
    // This is called once per frame
    void Update()
    {
        car.UpdateFuelCount(fuelBar,maxFuel, minFuel);
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

    
    // Detects contact between the car and fuel objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
            other.gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
            car.Collision();
    }

}