using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeEnd : MonoBehaviour
{
    Text End;
    TimeCount timeCurrent;
    // Start is called before the first frame update
    void Start()
    {
        End = GetComponent<Text>();
        End.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(timeCurrent);
        
    }
    public void TimeRE (float amt)
    {
        if(amt <= 0)
        {
            Debug.Log("End");
            End.gameObject.SetActive(true);
        }
    }
}
