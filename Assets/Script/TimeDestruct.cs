using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestruct : MonoBehaviour
{

    public float sTime = 4f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        sTime -= Time.deltaTime;
        if (sTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
