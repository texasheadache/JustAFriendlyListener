using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerFirst : MonoBehaviour
{


    [SerializeField] AudioSource mainMusic;
    [SerializeField] AudioSource talkMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMusicToSong()
    {
        mainMusic.mute = true;
        talkMusic.mute = false;
    }

    public void ChangeMusicToMain()
    {
        mainMusic.mute = false;
        talkMusic.mute = true;
    }

}
