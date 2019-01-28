using UnityEngine;

public class PlayerController : MonoBehaviour
{

    

    public GameObject carObject;

    public Car car;

    public runPythonScript test;


    //Vehicle car;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------START-------");
        car = carObject.GetComponent<Car>();
        test = new runPythonScript();
        
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will be smoother
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")) //Accelerate forwards
        {
            
            

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {  // rotate to the right
                car.RotateRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {   // rotate to the left
                car.RotateLeft();
            }

            car.Accelerate(1);
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s")) //Accelerate backwards
        {


            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                // rotate to the right
                car.RotateRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                // rotate to the left
                car.RotateLeft();
            }

            car.Accelerate(-1);
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            //brakes
            car.StopCarMotion();

        }
        else
        {
            // if no button pressed, stop car
            car.BrakeSlowly();

        }


        //TESTING PURPOSES (DARWON PART)

        //Testing style transfer script
        if(Input.GetKey(KeyCode.P))
        {
            test.runPythonStyleTransfer();
        }
    }


}