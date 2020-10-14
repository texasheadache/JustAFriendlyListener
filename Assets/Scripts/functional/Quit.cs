using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public  Pause paused;
    private GameObject player; 

    public void Start()
    {
        player = GameObject.Find("Player1Player");

    }

    public void OnButtonPress()
    {
        // Debug.Log("quitting"); 
        // Application.Quit();
         SceneManager.LoadScene("Menu");
        player.GetComponent<PlayerMovement>().UnFreeze();
        Time.timeScale = 1; 

        // paused.UnPauseGame();

    }

}
