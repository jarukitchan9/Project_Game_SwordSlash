using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    /// <summary>
    /// ////////This is Key Script
    /// </summary>
    public float Health = 100;
    public GameObject VFX;
    public AudioClip DeadSound;
    public int score;

    public int speed;
    Vector3 rotate = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        rotate.y = speed;
        transform.Rotate(rotate);

        if(Health <= 0)
        {
            Score.Valuescore += 1;
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float amt)
    {
        Health -= amt;

        if(Health <= 0)
        {
            Die();
            
            Debug.Log("Health");
        }
    }

    public void TakeDamageSword(float amt)
    {
        Health -= amt;

        if (Health <= 0)
        {
            Die();

            Debug.Log("Health");
        }
    }
    void Die()
    {
        if (gameObject.tag == "Key")
        {
            GameObject.Instantiate(VFX, this.transform.position, this.transform.rotation);

        }

        if (gameObject.tag == "Enemy")
        {
            GameObject.Instantiate(VFX,this.transform.position,this.transform.rotation);
            
        }
        
    }
}
