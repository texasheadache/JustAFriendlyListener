using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playPauseMusic;
    [SerializeField] AudioSource playCompMusic; 
    [SerializeField] GameObject player; 

    void Start()
    {
        //pausePanel.SetActive(false);
    }

       void Update()
       {
           if (Input.GetKeyDown(KeyCode.Escape))
           {
            Debug.Log("first"); 
               if (!pausePanel.activeInHierarchy)
               {
                Debug.Log("second");
                PauseGame();
            }

            else if (pausePanel.activeInHierarchy)
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
        pausePanel.SetActive(true);
        playMusic.mute = true;
        playPauseMusic.mute = false;
        player.GetComponent<PlayerMovement>().Freeze();
    }

    public  void  UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        playMusic.mute = false;
        playPauseMusic.mute = true;
        player.GetComponent<PlayerMovement>().UnFreeze();
    }
}
