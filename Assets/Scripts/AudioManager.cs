using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    void Start()
    {
        backgroundMusic = Resources.Load<AudioClip>("Audio/Castlevania II - Simon's Quest (NES) Music - Stage Theme Bloody Tears");
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
