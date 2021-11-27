using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDir : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + velocity);
    }
}
