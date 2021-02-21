using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollControl : MonoBehaviour
{
    bool NoWalkAttack = true;

    public Animation anim2;
    public float damage;
    public GameObject VFXSWORD;
    public GameObject Trail;
  

    // Start is called before the first frame update
    void Start()
    {
        Trail.SetActive(false);
        anim2 = GetComponent<Animation>();
        

    }

    // Update is called once per frame
    void Update()
    {

        damage = Random.Range(20, 34);

        
        if (Input.GetKeyDown(KeyCode.Mouse0) && NoWalkAttack == true)
        {
            SoundManager.Playsound("Swordslash");
            trailIn();
            anim2.Play();
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

    void trailIn()
    {

        StartCoroutine(CourA());

        IEnumerator CourA()
        {
            Trail.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Trail.SetActive(false);


        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);
            
            GameObject.Instantiate(VFXSWORD, this.transform.position, this.transform.rotation);
            Debug.Log("HelloSword");
        }

        if (other.CompareTag("Key"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);

            GameObject.Instantiate(VFXSWORD, this.transform.position, this.transform.rotation);
            Debug.Log("HelloSword");
        }
    }
}
