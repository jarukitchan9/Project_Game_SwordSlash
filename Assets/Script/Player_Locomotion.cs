using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Locomotion : MonoBehaviour
{
    bool NoWalkAttack = true;

    float velocityx = 0.0f;
    float velocityz = 0.0f;
    public float Acceleration = 0.5f;
    public float Deacceleration = 0.5f;
    int VelocityHashX;
    int VelocityHashZ;
    public Animator anim;
    float swordchang = 0.0f;
    int swordComb;

    float castINT = 0.0f;
    int cast;



    PlayerShooting cooldown;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


        VelocityHashX = Animator.StringToHash("Velocity X");
        VelocityHashZ = Animator.StringToHash("Velocity Z");

        cast = Animator.StringToHash("Cast");

        swordComb = Animator.StringToHash("SwordCombos");

    }

    // Update is called once per frame
    void Update()
    {
        bool fowardpressed = Input.GetKey(KeyCode.W);
        bool backwardpressed = Input.GetKey(KeyCode.S);
        bool leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);

        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool castpressed = Input.GetKeyDown(KeyCode.Mouse1);

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


        if (castpressed && castINT < 0.1f)
        {
            castINT += 0.1f;
            NoInterupt();
        }
        if (!castpressed && castINT > 0f)
        {
            castINT -= 0.1f;
        }

        if (attack && swordchang < 0.1f )
        {
            swordchang += 0.1f;
           
            NoInterupt();
        }
       
       
        if (!attack && swordchang > 0)
        {
            swordchang -= 0.1f;
            
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
        anim.SetFloat(cast, castINT);
    }
}
