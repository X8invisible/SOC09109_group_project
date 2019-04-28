using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //PUBLIC VARIABLES - appear in unity and can drag and drop objects into them
    public GameObject Car;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    //PRIVATE VARIABLES
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // transform references the transform of the gameobject that this script is attached to
        // transform.position is the camera's since the script is attached to the camera
        offset = transform.position - Car.transform.position;
    }

    // LateUpdate is called once per frame and guaranteed to run after all objects have been processed in update
    // use for follow cameras, procedural animation and gathering last known states
    void LateUpdate()
    {
        // as player is moved, camera is also moved without spinning
        transform.position = Car.transform.position + offset;
        
        //this is in order to not see the edge of the map
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
    }
}
