using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // public GameObject redcar = Transform.Find("Car");

    public float MaxSpeed = 7.0f;
    public float MaxSteer = 2.0f;
    public float Brakes = 0.2f;

    [SerializeField]  // force unity to also serialize private fields and not only public
    float Acceleration = 0.0f;
    float Steer = 0.0f;

    bool AccelFwd, AccelBwd;

    Vehicle car;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");
        car = new Car(transform);
        car.MaxSpeed = 7.0f;
        car.MaxSteer = 2.0f;
        car.Brakes = 0.2f;
        car.Acceleration = 0.0f;
        car.Steer = 0.0f;
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        // Accelerate forwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")){
            Debug.Log("----before car.Accelerate in PC----");
            car.Accelerate(1); // This used to be Accel(-1); and it would work
            Debug.Log("----after car.Accelerate in PC----");
        }
        // Accelerate backwards
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) 
            car.Accelerate(-1); // This works
        // Brakes
        else if (Input.GetKey(KeyCode.Space))
        {
            if (AccelFwd)
                StopAccel(1, Brakes);   // Brakes while in forward direction

            else if (AccelBwd)
                StopAccel(-1, Brakes);   // Brakes while in backward direction
        }

        else
        {
            if (AccelFwd)  //Applies Brakes slowly if no key is pressed while in forward direction
                StopAccel(1, 0.1f);

            else if (AccelBwd)    //Applies Brakes slowly if no key is pressed while in backward direction
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

    }

    // stop acceleration of car
    public void StopAccel(int Direction, float BreakingFactor)
    {
        if (Direction == 1)  // stop accelerating forwards
        {
            if (Acceleration >= 0.0f)
            {
                Acceleration -= BreakingFactor;

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
                    transform.Rotate(Vector3.forward * Steer);
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
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

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
                    transform.Rotate(Vector3.back * Steer);
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
                    transform.Rotate(Vector3.forward * Steer);
            }
            else
                AccelBwd = false;
        }
        if (Steer >= 0.0f)
            Steer -= 0.01f;

        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);

    }
    
    // SONAS
    // Detects contact between the car and fuel objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            other.gameObject.SetActive(false);
        }

    }

    // CAIO
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Obstacle"))
        {
            Acceleration = 0.0f;
        }
    }

}