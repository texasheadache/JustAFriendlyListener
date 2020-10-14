using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smallLoader2 : MonoBehaviour
{
    // public GameObject loadingScreen;
    // public string sceneToLoad;
    public int num;

    [SerializeField] Canvas canvas;
    [SerializeField] Canvas canvas2;


    public void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        canvas2 = GetComponentInChildren<Canvas>(true);

    }

    public void loading()
    {
        canvas.gameObject.SetActive(true);
    }

    public void loading2()
    {
        canvas2.gameObject.SetActive(true);
    }

    public void unLoading()
    {
        canvas.gameObject.SetActive(false);
    }

    public void coinFlip()
    {
        num = Random.Range(1, 3);

        if (num == 1)
        {
            Debug.Log(num);
            loading();
        }
        else
        {
            Debug.Log(num);
            loading2();
        }
    }
}