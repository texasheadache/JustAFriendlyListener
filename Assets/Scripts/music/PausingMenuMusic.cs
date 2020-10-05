using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingMenuMusic : MonoBehaviour
{

    [SerializeField] AudioSource MainMenuMusic;

    // Start is called before the first frame update
    void Awake()
    {
        playSong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSong()
    {
        MainMenuMusic.Play();
        // MainMenuMusic.mute = false; 
    }

    public void stopPlayingMainMenuSong()
    {
        MainMenuMusic.mute = true;
        Debug.Log("StoppedPlayingTunes");
    }
}
