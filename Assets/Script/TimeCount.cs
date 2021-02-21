using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float timeMax;
    public static float timeCurrent;
    float Minute;
    public GameObject GameEnd;
    Text ATime;
    // Start is called before the first frame update
    void Start()
    {
        
        ATime = GetComponent<Text>();
        timeCurrent = timeMax;
        GameEnd.gameObject.SetActive(false);
        //Minute = Mathf.Floor(timeCurrent % 60);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (timeCurrent > 0)
        {
            timeCurrent -= 1 * Time.deltaTime;
            ATime.text = "" + timeCurrent;
        }
        else
        {
            ATime.gameObject.SetActive(false);
            //ATime.text = "Game End";
            GameEnd.gameObject.SetActive(true);
            Time.timeScale = 0;
            timeCurrent = 0;
        }
        if (PlayerHealth.currentHitPoints <= 0)
        {
            ATime.gameObject.SetActive(false);
        }
        

        
    }
}
