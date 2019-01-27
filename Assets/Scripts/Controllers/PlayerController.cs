using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // MARIA
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

        else if (Input.GetKey(KeyCode.Space))  // Breaks
        {
            if (AccelFwd)
                car.StopAcc(1, Breaks);   // Breaks while in forward direction

            else if (AccelBwd)
                car.StopAcc(-1, Breaks);   // Breaks while in backward direction
        }
        else
        {
            if (AccelFwd)  //Applies breaks slowly if no key is pressed while in forward direction
                car.StopAcc(1, 0.1f);

            else if (AccelBwd)    //Applies breaks slowly if no key is pressed while in backward direction
                car.StopAcc(-1, 0.1f);
        }
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
            Acceleration = 0.0f;
    }

}