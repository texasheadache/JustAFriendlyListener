using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSlider1 : MonoBehaviour
{

    // private GameObject HallMusicSpeed;
    //image for slider for main song (first child of canvas holding slider)
    [SerializeField] GameObject MainMusicSpeed;

    // private GameObject Story1MusicSpeed;
    //image for slider for first "song" in scene (first child of canvas holding slider - image file?)
    [SerializeField] GameObject Story1MusicSpeed;

    //image for slider for dream1
    [SerializeField] GameObject dream1MusicSpeed;

    // private AudioSource mainMusic;
    // audiosource of the main music for scen
    [SerializeField] AudioSource mainMusic;

    //audiosource of the first "song" in scene
    // private AudioSource CompSong1;
    [SerializeField] AudioSource Story1Music;

    //audiosource for dream1 song
    [SerializeField] AudioSource dream1Music;

    // slider for the first "song" in scene
    [SerializeField] Slider Story1;

   // [SerializeField] Slider dream1; 

    // Start is called before the first frame update
    void Start()
    {
       // HallMusicSpeed = GameObject.Find("HallMusicSpeed");
       // Story1MusicSpeed = GameObject.Find("Story1MusicSpeed");
        MainMusicSpeed.SetActive(false);
        Story1MusicSpeed.SetActive(false);
        dream1MusicSpeed.SetActive(false);

      //  mainMusic = GameObject.Find("Sounds").GetComponent<AudioSource>();
      //  CompSong1 = GameObject.Find("CompSong1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (!mainMusic.mute)
            {

                if (!MainMusicSpeed.activeInHierarchy)
                {
                    showSlider();
                }
                else if (MainMusicSpeed.activeInHierarchy)
                {
                    closeSlider();
                }
            }
            else if (!Story1Music.mute)
            {
                if (!Story1MusicSpeed.activeInHierarchy)
                {
                    showSlider2();
                    Debug.Log("open Stor1");
                }
                else if (Story1MusicSpeed.activeInHierarchy)
                {
                    closeSlider2();
                    Debug.Log("closeStor1");
                }
            }

            
            /*
             else if (!dream1Music.mute)
            {
                if (!dream1MusicSpeed.activeInHierarchy)
                {
                    showSlider2();
                }
                else if (dream1MusicSpeed.activeInHierarchy)
                {
                    closeSlider2();
                }
            }
            */
            
        }
    }

    public void showSlider()
    {
        MainMusicSpeed.SetActive(true); 
    }

    public void closeSlider()
    {
        MainMusicSpeed.SetActive(false);
    }

    public void showSlider2()
    {
      
            Story1MusicSpeed.SetActive(true);
            Debug.Log("openS1");
    }

    public void closeSlider2()
    {
            Story1MusicSpeed.SetActive(false);
            Debug.Log("closeSto1");
    }

    /*
    public void showSlider3()
    {
        dream1MusicSpeed.SetActive(true);
        Debug.Log("open");
    }

    public void closeSlider3()
    {
        dream1MusicSpeed.SetActive(false);
        Debug.Log("closed");
    }
    */

    /*
    //optional function to reset settings on slider after conversation
    public void resetSlider2()
    {
        CompSong1.pitch = 1;
        Story1.value = 1f;
    }
    */

}
