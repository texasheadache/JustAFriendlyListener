using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSlider1 : MonoBehaviour
{

    //image for slider for main song (first child of canvas holding slider)
    [SerializeField] GameObject mainMusicSpeed;

    //image for slider for first "song" in scene (first child of canvas holding slider - image file?)
    [SerializeField] GameObject oneMusicSpeed;

    //image for slider for dream1
    [SerializeField] GameObject twoMusicSpeed;

    //image for slider for third "song" in scene
    [SerializeField] GameObject threeMusicSpeed; 

    // audiosource of the main music for scene
    [SerializeField] AudioSource mainMusic;
    
    //audiosource of the first "song" in scene
    // private AudioSource CompSong1;
    [SerializeField] AudioSource oneMusic;

    //audiosource for second "song" in scene
    [SerializeField] AudioSource twoMusic;

    //audiosource for third "song" in scene
    [SerializeField] AudioSource threeMusic; 

    // Start is called before the first frame update
    void Start()
    {
        mainMusicSpeed.SetActive(false);
        oneMusicSpeed.SetActive(false);
        twoMusicSpeed.SetActive(false);
        threeMusicSpeed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (!mainMusic.mute)
            {

                if (!mainMusicSpeed.activeInHierarchy)
                {
                    showSlider();
                }
                else if (mainMusicSpeed.activeInHierarchy)
                {
                    closeSlider();
                }
            }

            /*
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
            */

            
            else
            {
                showSlider2();
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
        mainMusicSpeed.SetActive(true); 
    }

    public void closeSlider()
    {
        mainMusicSpeed.SetActive(false);
    }


    public void showSlider2()
    {
        if (!oneMusic.mute)
        {
            if (!oneMusicSpeed.activeInHierarchy)
            {
                oneMusicSpeed.SetActive(true);
                Debug.Log("open Stor1");
            }
            else if (oneMusicSpeed.activeInHierarchy)
            {
                oneMusicSpeed.SetActive(false);
                Debug.Log("closeStor1");
            }
        }

        else if (!twoMusic.mute)
        {
            if (!twoMusicSpeed.activeInHierarchy)
            {
                twoMusicSpeed.SetActive(true);
                Debug.Log("dreamOn");
            }
            else if (twoMusicSpeed.activeInHierarchy)
            {
                twoMusicSpeed.SetActive(false);
                Debug.Log("dreamOff");
            }
        }

        else if (!threeMusic.mute)
        {
            if (!threeMusicSpeed.activeInHierarchy)
            {
                threeMusicSpeed.SetActive(true);
                Debug.Log("threeOn");
            }
            else if (threeMusicSpeed.activeInHierarchy)
            {
                threeMusicSpeed.SetActive(false);
                Debug.Log("threeOff");
            }
        }
    }

    public void closeSlider2()
    {
        if (oneMusicSpeed.activeInHierarchy)
        {
            oneMusicSpeed.SetActive(false);
            Debug.Log("closeSto1");
        }

        else if (twoMusicSpeed.activeInHierarchy)
        {
            twoMusicSpeed.SetActive(false);
            Debug.Log("closeDreamies");
        }

        else if (threeMusicSpeed.activeInHierarchy)
        {
            threeMusicSpeed.SetActive(false);
            Debug.Log("closeThree");
        }
    }






    /*
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
