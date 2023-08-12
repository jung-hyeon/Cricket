using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        /*BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();
        if (backmusic.isPlaying) return;
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic);
        }*/
    }
}
