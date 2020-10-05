using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject optionsPanel;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playPauseMusic;
   // private AudioSource playPauseMusic; 
    [SerializeField] AudioSource playCompMusic; 
    [SerializeField] GameObject player; 

    void Start()
    {
        //pausePanel.SetActive(false);
        playPauseMusic = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();
        Debug.Log("FoundIt");
    }

       void Update()
       {
           if (Input.GetKeyDown(KeyCode.Escape))
           {
            Debug.Log("first"); 
               if (!pausePanel.activeInHierarchy && !optionsPanel.activeInHierarchy)
               {
                Debug.Log("second");
                PauseGame();
            }

            else if (pausePanel.activeInHierarchy || optionsPanel.activeInHierarchy)
            {
                UnPauseGame();
                Debug.Log("third");
                playMusic.mute = false;
                player.GetComponent<PlayerMovement>().UnFreeze();
            }
        }
       }

    public  void  PauseGame()
    {
        Time.timeScale = 0;
        if (!optionsPanel.activeInHierarchy && !pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
        playMusic.mute = true;
        playPauseMusic.mute = false;
        Debug.Log("Unmuted");
        player.GetComponent<PlayerMovement>().Freeze();
    }

    public  void  UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        playMusic.mute = false;
        playPauseMusic.mute = true;
        player.GetComponent<PlayerMovement>().UnFreeze();
    }


}
