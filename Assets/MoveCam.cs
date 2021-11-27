using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    float xSpeed;
    float ySpeed;
    float zSpeed;

    public float moveSpeed;

    public float lookSensitivity;
    float xRotation;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        
        //Move
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");
        float yInput = 0.0f; 
        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift))
        {
            yInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space))
        {
            yInput = -1.0f;
        }
        if ((Input.GetKeyUp(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKeyUp(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space))) {
            zInput = 0.0f;
        }
        
        xSpeed = moveSpeed * xInput;
        ySpeed = moveSpeed * yInput;
        zSpeed = moveSpeed * zInput;

        Vector3 compositeMovementVec = (xSpeed * transform.right) + (ySpeed * transform.up) + (zSpeed * transform.forward);

        this.transform.position = this.transform.position + compositeMovementVec;
    }

    void Look() {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
        
        //Find current look rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        float desiredX = rot.y + mouseX;


        //Rotate, and also make sure we dont over- or under-rotate.
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        this.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }
}
