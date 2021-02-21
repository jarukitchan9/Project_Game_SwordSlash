using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float speed = 2f;
    public int damage;

    private Transform thisTransform;
    public Transform SpellHitFX;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        SoundManager.Playsound("Fireball");
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position += Time.deltaTime * speed * thisTransform.forward;
        damage = Random.Range(20, 27);
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", damage);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(SpellHitFX, pos, rot);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Prop")
        {
            

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(SpellHitFX, pos, rot);
            Destroy(gameObject);
        }
    }
}
