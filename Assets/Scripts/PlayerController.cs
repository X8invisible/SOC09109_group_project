using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES - appear in unity and can drag and drop objects into them
    public float speed;

    // PRIVATE VARIABLES
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // is called x amount of times per frame, so physics won't be applied every frame and will
    // be smoother
    private void FixedUpdate()
    {
        // reads the axes set up in the Conventional Game Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //a vector is a coordinate with direction eg. (x, y) on an object
        // will move x to the right/left and y up/down.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //The object will be accelerated by the force according to the law
        // force = mass x acceleration - the larger the mass, the greater
        // the force required to accelerate to a given speed.
        rb2d.AddForce(movement * speed);
    }
}
