using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerSecond : MonoBehaviour
{


    private AudioSource mainMusic;
    private AudioSource talkMusic;
    // Start is called before the first frame update
    void Start()
    {
        mainMusic = GameObject.Find("Sounds").GetComponent<AudioSource>();
        talkMusic = GameObject.Find("strangerNoise1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void HallSong1()
    {
        mainMusic.mute = true;
        talkMusic.mute = false;
    }

    public void MainMusic()
    {
        mainMusic.mute = false;
        talkMusic.mute = true;
    }

}
