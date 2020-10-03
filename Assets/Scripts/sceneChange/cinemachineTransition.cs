using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class cinemachineTransition : MonoBehaviour
{

  //  private CinemachineVirtualCamera cva;
    private CinemachineConfiner confiner;
   // private Collider2D collider2; 
   // public Collider2D collider;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testingggg");
        confiner.InvalidatePathCache();
       // collider2 = GameObject.FindGameObjectWithTag("CinemachineConfiner1").GetComponent<BoxCollider2D>();
        //  confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("CinemachineConfiner1").GetComponent<CompositeCollider2D>();
        confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("CinemachineConfiner1").GetComponent<Collider2D>();
       // confiner.m_BoundingShape2D = collider2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
