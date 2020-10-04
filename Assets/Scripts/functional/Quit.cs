using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public  Pause paused; 
   
    public void OnButtonPress()
    {
        // Debug.Log("quitting"); 
        // Application.Quit();
        SceneManager.LoadScene("Menu");


    }

}
