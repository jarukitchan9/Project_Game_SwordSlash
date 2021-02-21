using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public Transform CastingPosition;
    public GameObject SpellPrefab;

    public float Cooldown = 1f;
    public float Ratefire = 1f;

    public AudioClip firesound;

    bool isFire = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Cooldown -= Time.deltaTime;
        
        if(isFire == true)
        {
            Fire();
        }

        

        
        
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            isFire = true;
        }
        else
        {
            isFire = false;
        }

    }
    void Fire()
    {
        if (Cooldown > 0)
        {
            return;
        }
        if (isFire == true)
        {
            StartCoroutine(coroutineA());

            IEnumerator coroutineA()
            {
                yield return new WaitForSeconds(0.3f);
                GameObject.Instantiate(SpellPrefab, CastingPosition.position, CastingPosition.rotation);
                






            }
            
        }
        Cooldown = Ratefire;

    }
}
