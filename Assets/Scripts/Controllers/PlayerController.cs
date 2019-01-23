using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //GameObject car = GameObject.Find("Car");

    public Car car;

    // Start is called before the first frame update
    void Start()
    {

    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")) //Accelerate forwards
            car.Accel(1);

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) //Accelerate backwards
            car.Accel(-1);

        else if (Input.GetKey(KeyCode.Space))  // Breaks
        {
            if (car.AccelFwd)
                car.StopAccel(1, car.Breaks);   // Breaks while in forward direction

            else if (car.AccelBwd)
                car.StopAccel(-1, car.Breaks);   // Breaks while in backward direction
        }

        else
        {
            if (car.AccelFwd)  //Applies breaks slowly if no key is pressed while in forward direction
                car.StopAccel(1, 0.1f);

            else if (car.AccelBwd)    //Applies breaks slowly if no key is pressed while in backward direction
                car.StopAccel(-1, 0.1f);
        }

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

}
