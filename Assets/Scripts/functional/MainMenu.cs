using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Hall1");
    }

    public void QuittingGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

}
