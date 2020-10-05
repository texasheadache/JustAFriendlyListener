using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public float pitchValue = 1.0f; 
    public AudioClip MainMenuSong; 
    public float sliderPitch;

    private AudioSource MainMenuMusic;
    private float low = 0.5f;
    private float high = 2.0f; 
    // Start is called before the first frame update
    void Awake()
    {
        MainMenuMusic = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        MainMenuMusic.clip = MainMenuSong;
        MainMenuMusic.loop = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        pitchValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), sliderPitch, low, high);
        MainMenuMusic.pitch = sliderPitch;
    }

}
