using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour 
{
    AudioSource currentAudio;
    public AudioClip defaultMusic;
    public AudioClip dieMusic;
    bool switchOnceFlag = false;


	// Use this for initialization
	void Start () 
    {
        currentAudio = GetComponent<AudioSource>();
        currentAudio.clip = defaultMusic;
        currentAudio.Play();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!MovementController.getIsFishLives()&&!switchOnceFlag)
        {
            changeMusic(dieMusic);
            switchOnceFlag = true;
        }
	}

    void changeMusic(AudioClip newAudio)
    {
        currentAudio.clip = newAudio;
        currentAudio.Play();
    }
}
