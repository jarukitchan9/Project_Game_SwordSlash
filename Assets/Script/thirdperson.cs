using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdperson : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float speed = 6f;
    public float speedforward = 3f;

    public float mulForward;
    public float speedforX = 10f;

    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 directionx = new Vector3(horizontal, 0f, 0f).normalized;
        Vector3 directionz = new Vector3(0f, 0f, vertical).normalized;

        bool pressedforward = Input.GetKey(KeyCode.W);
        bool pressedbackward = Input.GetKey(KeyCode.S);


        

        if (pressedforward && directionz.magnitude >= 0.1f)     //When pressed W  Increase speed only forward
        {
            float targetAngle = Mathf.Atan2(directionz.x, directionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speedforward * Time.deltaTime);
        }
        if (pressedbackward && directionz.magnitude >= 0.1f)   //When pressed S Default Speed 
        {
            //float targetAngle = Mathf.Atan2(directionz.x, directionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(directionz * speed  * Time.deltaTime);
        }
        if (directionx.magnitude >= 0.1f)   //Speed for X
        {
            //float targetAngle = Mathf.Atan2(directionx.x, directionx.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(directionx * speedforX * Time.deltaTime);
        }
    }
}