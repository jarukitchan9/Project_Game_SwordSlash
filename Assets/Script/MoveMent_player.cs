using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent_player : MonoBehaviour
{
    public int speed = 10;
    private float xAxis;
    private float zAxis;
    Vector3 currentposition = new Vector3(0, 0, 0);
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        currentposition.x = xAxis;
        currentposition.z = zAxis;

        rb.AddForce(currentposition * speed);
        
    }
}
