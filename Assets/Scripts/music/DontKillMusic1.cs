using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKillMusic1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
