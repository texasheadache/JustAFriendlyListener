using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicSlider1 : MonoBehaviour
{

    private GameObject MusicSlider; 
    // Start is called before the first frame update
    void Start()
    {
        MusicSlider = GameObject.Find("MusicSliderPanel");
        MusicSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!MusicSlider.activeInHierarchy)
            {
                showSlider();
            }
            else if (MusicSlider.activeInHierarchy)
            {
                closeSlider();
            }
        }
    }

    public void showSlider()
    {
        MusicSlider.SetActive(true); 
    }

    public void closeSlider()
    {
        MusicSlider.SetActive(false);
    }
}
