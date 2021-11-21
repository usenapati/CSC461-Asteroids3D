using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    float xSpeed;
    float ySpeed;
    float zSpeed;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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


        Vector3 deltaPos = new Vector3(xSpeed, ySpeed, zSpeed);
        this.transform.position = this.transform.position + deltaPos;
    }
}
