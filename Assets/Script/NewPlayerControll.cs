using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerControll : MonoBehaviour
{
    private float xAxis;
    private float zAxis;
    public CharacterController controller;
    public float speed = 20f;

    bool NoWalkAttack = true;

    public float rotationPower = 3f;
    public Vector2 _look;

    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");



        Vector3 currentpositionz = new Vector3(0, 0, zAxis).normalized;
        Vector3 currentpositionx = new Vector3(xAxis, 0, 0).normalized;

        bool fowardpressed = Input.GetKey(KeyCode.W);
        bool backwardpressed = Input.GetKey(KeyCode.S);
        bool leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);
        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool castpressed = Input.GetKeyDown(KeyCode.Mouse1);


        if (fowardpressed && currentpositionz.magnitude >= 0.1f && NoWalkAttack == true)     //When pressed W  Increase speed only forward
        {

            float targetAngle = Mathf.Atan2(currentpositionz.x, currentpositionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);


        }

        if (backwardpressed && currentpositionz.magnitude >= 0.1f && NoWalkAttack == true)   //When pressed S Default Speed 
        {


            float targetAngle = Mathf.Atan2(currentpositionz.x, currentpositionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if (currentpositionx.magnitude >= 0.1f && NoWalkAttack == true)   //Speed for X
        {

            float targetAngle = Mathf.Atan2(currentpositionx.x, currentpositionx.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if (attack)
        {
            
            NoInterupt();
        }
        if (castpressed)
        {

            NoInterupt();
        }
        

        void NoInterupt()
        {
            StartCoroutine(CourA());

            IEnumerator CourA()
            {
                NoWalkAttack = false;
                yield return new WaitForSeconds(0.5f);
                NoWalkAttack = true;


            }
        }
    }
}
