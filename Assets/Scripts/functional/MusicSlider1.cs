using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSlider1 : MonoBehaviour
{

    private GameObject HallMusicSpeed;
    private GameObject Story1MusicSpeed; 
    private AudioSource mainMusic;
    private AudioSource CompSong1;
    [SerializeField] Slider Story1;

    // Start is called before the first frame update
    void Start()
    {
        HallMusicSpeed = GameObject.Find("HallMusicSpeed");
        Story1MusicSpeed = GameObject.Find("Story1MusicSpeed");
        HallMusicSpeed.SetActive(false);
        Story1MusicSpeed.SetActive(false);

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

                if (!HallMusicSpeed.activeInHierarchy)
                {
                    showSlider();
                }
                else if (HallMusicSpeed.activeInHierarchy)
                {
                    closeSlider();
                }
            }
            else if (!CompSong1.mute)
            {
                if (!Story1MusicSpeed.activeInHierarchy)
                {
                    showSlider2();
                }
                else if (Story1MusicSpeed.activeInHierarchy)
                {
                    closeSlider2();
                }
            }
        }
    }

    public void showSlider()
    {
        HallMusicSpeed.SetActive(true); 
    }

    public void closeSlider()
    {
        HallMusicSpeed.SetActive(false);
    }

    public void showSlider2()
    {
        Story1MusicSpeed.SetActive(true);
    }

    public void closeSlider2()
    {
        Story1MusicSpeed.SetActive(false);
    }


    /*
    //optional function to reset settings on slider after conversation
    public void resetSlider2()
    {
        CompSong1.pitch = 1;
        Story1.value = 1f;
    }
    */

}
