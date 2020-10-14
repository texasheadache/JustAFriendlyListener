using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smallLoader : MonoBehaviour
{
   // public GameObject loadingScreen;
   // public string sceneToLoad;

    [SerializeField] Canvas canvas; 

    public void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
    }

    public void loading()
    {
        canvas.gameObject.SetActive(true);
    }

}
