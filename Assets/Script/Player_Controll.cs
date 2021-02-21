using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    public Animator anim;

    public float speed = 20f;   //Default Speed
    public float speedforX = 10f;  // For Strafe Left Right
    
    private float xAxis;
    private float zAxis;
    
    public float mulForward;  // For Increase speedforward

    float swordchang = 0.0f;
    float velocityx = 0.0f;
    float velocityz = 0.0f;
    
    public float Acceleration = 0.5f;
    public float Deacceleration = 0.5f;
    int VelocityHashX;
    int VelocityHashZ;
    int swordComb;
    

    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public CharacterController controller;

    bool NoWalkAttack = true;
    
    





    void Start()
    {
        anim = GetComponent<Animator>();
        

        VelocityHashX = Animator.StringToHash("Velocity X");
        VelocityHashZ = Animator.StringToHash("Velocity Z");
        swordComb = Animator.StringToHash("SwordCombos");



    }


    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        

        Vector3 currentpositionz = new Vector3(0, 0, zAxis).normalized;
        Vector3 currentpositionx = new Vector3(xAxis, 0, 0).normalized;

        





        bool fowardpressed = Input.GetKey(KeyCode.W);
        bool backwardpressed = Input.GetKey(KeyCode.S);
        bool leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);

        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool cast = Input.GetKeyDown(KeyCode.Mouse1);


        bool iswalking = GetComponent<Animator>();
        bool isbackwalking = GetComponent<Animator>();


        if (fowardpressed && currentpositionz.magnitude >= 0.1f && NoWalkAttack == true)     //When pressed W  Increase speed only forward
        {
            float targetAngle = Mathf.Atan2(currentpositionz.x, currentpositionz.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed  * Time.deltaTime);


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
            controller.Move(moveDir * speedforX * Time.deltaTime);
        }





        if (fowardpressed && velocityz < 0.5f && NoWalkAttack == true)               //Forward
        {

            velocityz += Time.deltaTime * Acceleration;
            
        }
        if (!fowardpressed && velocityz > 0.0f && NoWalkAttack == true)
        {
            velocityz -= Time.deltaTime * Deacceleration;

        }
        if (backwardpressed && velocityz > -0.5f && NoWalkAttack == true)     //Backward
        {
            velocityz -= Time.deltaTime * Acceleration;
        }
        if (!backwardpressed && velocityz < 0.0f && NoWalkAttack == true)
        {
            velocityz += Time.deltaTime * Deacceleration;
        }

        if (rightpressed && velocityx < 0.5f)  //Right
        {
            velocityx += Time.deltaTime * Acceleration;
        }
        if (!rightpressed && velocityx > 0.0f)
        {
            velocityx -= Time.deltaTime * Deacceleration;
        }
        if (leftpressed && velocityx > -0.5f)     //Left
        {
            velocityx -= Time.deltaTime * Acceleration;
        }
        if (!leftpressed && velocityx < 0.0f)
        {
            velocityx += Time.deltaTime * Deacceleration;
        }



        if(cast )

        if(attack && swordchang < 0.1f)
        {
            swordchang += 0.1f;
            NoInterupt();
        }
        if (attack && swordchang >= 0.25f && swordchang < 0.3f)
        {
            swordchang += 0.1f;
        }
        if (!attack && swordchang >= 0.0f)
        {
            swordchang -= Time.deltaTime * Deacceleration;

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

        

        anim.SetFloat(VelocityHashZ, velocityz);
        anim.SetFloat(VelocityHashX, velocityx);

        anim.SetFloat(swordComb, swordchang);

        







    }
}
