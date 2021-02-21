
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    public Animation anim;
    public GameObject vfx;
    public float checkDistance = 10.0f;
    public float checkWalk = 5.0f;
    private bool isInterrupt = false;
    private bool dead = false;
    private int counter = 3;

    public GameObject healthbatUI;
    public Slider slider;

    public float hitPoints = 100f;
    public float currentHitPoints;
    public GameObject destroyFX;

    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        anim = GetComponent<Animation>();
        currentHitPoints = hitPoints;

        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        float CalculateHealth()
        {
            return currentHitPoints / hitPoints;
        }
        damage = Random.Range(99, 120);

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (!isInterrupt)
        {

            if (Vector3.Distance(player.position, this.transform.position) < checkDistance && !dead)
            {
                // do something
                //
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                //direction.z = -1.0f;

                if (direction.magnitude > checkWalk)
                {
                    
                    this.transform.Translate(0, 0, 0.05f);

                    animator.SetBool("isWalking", true);
                    
                }
                
                else
                {
                    
                    
                    animator.SetBool("isWalking", false);
                    

                }
            }
        }




    }

    public void TakeDamage(float amt)
    {
        currentHitPoints -= amt;
        if(currentHitPoints < 100)
        {
            if (currentHitPoints <= 0)
            {
                Destroy(gameObject);
                currentHitPoints = 0;

                Die();
            }
            checkDistance = 100;
        }

        
    }
    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            Instantiate(destroyFX, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        if (gameObject.tag == "Prop")
        {
            Instantiate(destroyFX, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("TakeDamagePlayer", damage);

            GameObject.Instantiate(vfx, this.transform.position, this.transform.rotation);
            Debug.Log("HelloSword");
        }
    }
    
}
