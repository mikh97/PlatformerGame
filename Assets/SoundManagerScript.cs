using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip walkingSound, jumpSound, deathSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        walkingSound = Resources.Load<AudioClip>("walking");
        jumpSound = Resources.Load<AudioClip>("jump");
        deathSound = Resources.Load<AudioClip>("death");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walking":
                audioSrc.PlayOneShot(walkingSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
        }
    }
}
