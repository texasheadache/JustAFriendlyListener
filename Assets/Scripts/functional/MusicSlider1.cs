using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSlider1 : MonoBehaviour
{

    private GameObject MusicSlider;
    private GameObject MusicSlider2; 
    private AudioSource mainMusic;
    private AudioSource CompSong1; 
    // Start is called before the first frame update
    void Start()
    {
        MusicSlider = GameObject.Find("MusicSliderPanel");
        MusicSlider2 = GameObject.Find("MusicSliderPanel2");
        MusicSlider.SetActive(false);
        MusicSlider2.SetActive(false);

        mainMusic = GameObject.Find("Sounds").GetComponent<AudioSource>();
        CompSong1 = GameObject.Find("CompSong1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (!mainMusic.mute)
            {

                if (!MusicSlider.activeInHierarchy)
                {
                    showSlider();
                }
                else if (MusicSlider.activeInHierarchy)
                {
                    closeSlider();
                }
            }
            else if (!CompSong1.mute)
            {
                if (!MusicSlider2.activeInHierarchy)
                {
                    showSlider2();
                }
                else if (MusicSlider2.activeInHierarchy)
                {
                    closeSlider2();
                }
            }
        }
    }

    public void showSlider()
    {
        MusicSlider.SetActive(true); 
    }

    public void closeSlider()
    {
        MusicSlider.SetActive(false);
    }

    public void showSlider2()
    {
        MusicSlider2.SetActive(true);
    }

    public void closeSlider2()
    {
        MusicSlider2.SetActive(false);
        CompSong1.pitch = 1; 
    }
}
