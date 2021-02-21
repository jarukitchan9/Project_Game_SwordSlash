using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Swordslashsound, FireBall;

    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        FireBall = Resources.Load<AudioClip>("Fireball");
        Swordslashsound = Resources.Load<AudioClip>("Swordslash");
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound (string clip)
    {
        switch (clip)
        {

            case "Swordslash":
                audioSrc.PlayOneShot(Swordslashsound);
                break;
            case "Fireball":
                audioSrc.PlayOneShot(FireBall);
                break;
        }
        


        }
}
