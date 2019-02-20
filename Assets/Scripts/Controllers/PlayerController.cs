using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // For accessing the car game object so we can access it's components through the car script
    public GameObject carGameObject;

    // a script that is for testing purposes
    public runPythonScript test;

    // The car script that changes the car game object
    private Car car;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");
        car = carGameObject.GetComponent<Car>();
        test = new runPythonScript();
    }

    // This is called once per frame
    void Update()
    {
        car.UpdateFuelCount();
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w") || (Input.GetAxis("CarForward")>0)) //Accelerate forwards
        {
            if (!Input.GetKey(KeyCode.Space)) // if space key is pressed the car won't run
                car.Accelerate(1);            // the brakes have priority over the acceleration

            if (Input.GetKey(KeyCode.Space)) // if pressed only a litle but a couple of times
                car.StopCarMotion();         // it will slowly slow down

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d") || (Input.GetAxis("CarDirection")>0))
            {  // rotate to the right
                car.RotateRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") || (Input.GetAxis("CarDirection")<0))
            {
                // rotate to the left
                car.RotateLeft();
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s") || (Input.GetAxis("CarBack")>0)) //Accelerate backwards
        {
            car.Accelerate(-1);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d") || (Input.GetAxis("CarDirection")>0))
            {
                // rotate to the right
                car.RotateRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") || (Input.GetAxis("CarDirection")<0))
            { // rotate to the left
                car.RotateLeft();
            }
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            // Brakes
            car.StopCarMotion();
        }
        else
        {

            //NEEDS TWEAKING
            // if no button pressed, stop car
            car.BrakeSlowly();
        }

        //TESTING PURPOSES (DARWON PART)

        //Testing style transfer script
        if (Input.GetKey(KeyCode.P))
        {
            test.runPythonStyleTransfer();
        }
    }



}
