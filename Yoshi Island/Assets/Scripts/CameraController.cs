using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables for movement
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    //Variable to add the camera and get the position
    public Transform cameraTransform;
    
    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    //Suport for mouse drag
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    //Limits
    public float minZoom, maxZoom;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        // Control for zoom
        if(Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
            if (newZoom.x > maxZoom || newZoom.y > maxZoom || newZoom.x < minZoom || newZoom.y < minZoom) 
            {
                newZoom = cameraTransform.localPosition;
            }
        }

        // Get the position when the left mouse is cliked for it to be the
        // starting point for the drag
        if(Input.GetMouseButtonDown(0))
        {
           Plane plane = new Plane(Vector3.up, Vector3.zero);
           
           // Returns a ray going from camera through a screen point
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

           //To store entry point of the ray cast
           float entry;
           
           // Do raycast on the plane and set it as start position
           if (plane.Raycast(ray, out entry))
           {
                dragStartPosition = ray.GetPoint(entry);
           }
        }

        //If mouse is still held down, do another raycast to store the current position
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
           
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           float entry;
           if (plane.Raycast(ray, out entry))
           {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
           }
        }
        
        // Using right mouse 
        if (Input.GetMouseButtonDown(1))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * -(difference.x / 5f));
        }

        /* Updates */
        //Updates camera position
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);

        //Update zoom level
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

        //Update camera rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }

    
    
}
