using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100f;
    public static float currentHitPoints;
    public GameObject destroyFX;
    public GameObject GameEnd;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = hitPoints;

    }

    public void TakeDamagePlayer(float amt)
    {
        currentHitPoints -= amt;

        if (currentHitPoints <= 0)
        {
            
            currentHitPoints = 0;
            Destroy(gameObject);
            Time.timeScale = 0;
            GameEnd.gameObject.SetActive(true);
        }

        
        {

        }
    }

    // Update is called once per frame
    
}
